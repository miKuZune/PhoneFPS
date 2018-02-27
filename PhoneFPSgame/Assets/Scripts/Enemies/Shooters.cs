using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour {
    //Goals:
    //AI will walk toward player until they are at a suitable distance and can see the player.
    //When these conditions are met the AI will shoot at the player. 
    //The AI standstill to shoot and move inbetween shots.

    StateMachine SM;
    GameObject player;

    public float minShootDistance;
    public float maxShootDistance;

    public GameObject bullet;
    public float fireRate;

	float timeSinceLastFire;

    bool isShooting;
	bool isRunningAway;
	// Use this for initialization
	void Start () {
        isShooting = false;
		isRunningAway = false;
        SM = new StateMachine();
        player = GameObject.FindGameObjectWithTag("Player");
        SM.ChangeState(new RunAtPlayer(this.gameObject));

        
	}
	
    public void Shoot()
    {
        GameObject bulletShot = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletShot.GetComponent<Bullet>().owner = this.gameObject;

        Vector3 dirToPlayer = player.transform.position - transform.position;
        dirToPlayer.Normalize();
        bulletShot.GetComponent<Bullet>().direction = dirToPlayer;
    }

	bool CanSeePlayer()
	{
		bool canSee = false;

		Vector3 toPlayer = player.transform.position - transform.position;
		RaycastHit hitInfo;

		if (Physics.Raycast (transform.position, toPlayer, out hitInfo)) 
		{
			if (hitInfo.transform.tag == player.tag) 
			{
				canSee = true;
			}
		}

		return canSee;
	}

	bool IsTooCloseToPlayer()
	{
		bool tooClose = false;

		float distToPlayer = Vector3.Distance (player.transform.position, transform.position);

		if (distToPlayer < minShootDistance && CanSeePlayer()) {
			tooClose = true;
		}

		return tooClose;
	}

    bool InShootingRange()
    {
        bool isInRange = false;

        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distToPlayer > minShootDistance && distToPlayer < maxShootDistance)
        {
            isInRange = true;
        }
		Debug.Log (isInRange);

        return isInRange;
    }

	// Update is called once per frame
	void Update ()
    {
        if(InShootingRange() && !isShooting)
        {
			if (CanSeePlayer () && timeSinceLastFire >= fireRate) {
				//SM.ChangeState(new ShootAtPlayer(this.gameObject));
				Shoot();
				isShooting = true;
				isRunningAway = false;
				timeSinceLastFire = 0;
			}
			timeSinceLastFire += Time.deltaTime;
        }

		if(!InShootingRange() && isShooting)
        {
			SM.ChangeState(new RunAtPlayer(this.gameObject));
			isShooting = false;
			isRunningAway = false;
        }

		else if (IsTooCloseToPlayer () && !isRunningAway) 
		{
			SM.ChangeState (new RunFromPlayer (this.gameObject));
			isShooting = false;
			isRunningAway = true;
		}

        SM.Update();
	}
}
