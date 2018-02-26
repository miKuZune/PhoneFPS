using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : IState {

    public ShootAtPlayer(GameObject owner) { this.owner = owner; }


    public void Enter()
    {
        bullet = owner.GetComponent<Shooters>().bullet;
        fireRate = owner.GetComponent<Shooters>().fireRate;
        bulletStartPos = owner.GetComponentInChildren<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Shooting at player");
    }
    public void Execute()
    {
        timeSinceLastShot += Time.deltaTime;

        if(timeSinceLastShot > fireRate)
        {

            //Rotate towards the player
            Vector3 targetDir = player.transform.position - owner.transform.position;
            float turnSpeed = 20 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(owner.transform.forward, targetDir, turnSpeed, 0.0f);
            owner.transform.rotation = Quaternion.LookRotation(newDir);


            owner.GetComponent<Shooters>().Shoot();
            timeSinceLastShot = 0;
        }

    }
    public void Exit()
    {
        Debug.Log("No longer shooting at player");
    }

    //Variables
    GameObject owner;

    GameObject bullet;
    Transform bulletStartPos;
    GameObject player;

    float fireRate;
    float timeSinceLastShot = 0;
}
