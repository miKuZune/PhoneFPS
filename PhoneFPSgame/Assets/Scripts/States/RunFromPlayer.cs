using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunFromPlayer : IState {

	GameObject owner;
	public RunFromPlayer(GameObject owner){this.owner = owner;}

	GameObject player;

	Vector3 GetNewPos()
	{
		Vector3 newPos = Vector3.zero;

		Vector3 toPlayer = player.transform.position - owner.transform.position;
		toPlayer.Normalize ();

		const float distMultiplier = -25f;

		newPos = owner.transform.position + (toPlayer * distMultiplier);

		return newPos;
	}

	public void Enter()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		owner.GetComponent<NavMeshAgent> ().speed = 3.5f;
		Debug.Log ("Running from player.");
	}
	public void Execute()
	{
		owner.GetComponent<NavMeshAgent> ().destination = GetNewPos();
	}
	public void Exit()
	{
		Debug.Log ("No longer running from player");
	}
}
