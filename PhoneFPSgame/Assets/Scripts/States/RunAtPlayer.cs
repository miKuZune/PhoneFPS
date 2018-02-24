using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RunAtPlayer : IState {

	GameObject owner;
	public RunAtPlayer(GameObject owner) { this.owner = owner; }

	//Variables
	NavMeshAgent NMA;
	GameObject player;

	const float closeEnough = 2.0f;


	public void Enter()
	{

		NMA = owner.GetComponent<NavMeshAgent> ();
        NMA.speed = 3.5f;
        player = GameObject.FindGameObjectWithTag ("Player");
		//Debug.Log ("Chasing player");
	}
	public void Execute()
	{
        Debug.Log("RunningAtPlayer");
		NMA.destination = player.transform.position;
	}
	public void Exit()
	{
		NMA.speed = 0;
		//Debug.Log ("Not chasing player anymore");
	}
}
