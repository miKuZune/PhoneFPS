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

    bool isShooting;
	// Use this for initialization
	void Start () {
        isShooting = false;
        SM = new StateMachine();
        player = GameObject.FindGameObjectWithTag("Player");
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

        if(!isShooting)
        {
            if(InShootingRange())
            {
                //Shoot
            }
        }
        else
        {
            if(!InShootingRange())
            {
                //Stop shooting
            }
        }


        SM.Update();
	}
}
