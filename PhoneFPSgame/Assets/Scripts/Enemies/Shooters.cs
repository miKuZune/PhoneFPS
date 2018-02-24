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

    bool isShooting;
	// Use this for initialization
	void Start () {
        isShooting = false;
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

    bool InShootingRange()
    {
        bool isInRange = false;

        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distToPlayer > minShootDistance && distToPlayer < maxShootDistance)
        {
            isInRange = true;
        }

        return isInRange;
    }

	// Update is called once per frame
	void Update ()
    {
        if(InShootingRange() && !isShooting)
        {
            SM.ChangeState(new ShootAtPlayer(this.gameObject));
            isShooting = true;
        }else if(!InShootingRange() && isShooting)
        {
            SM.ChangeState(new RunAtPlayer(this.gameObject));
            isShooting = false;
        }


        SM.Update();
	}
}
