using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : IState {

	GameObject owner;
	public Wander(GameObject owner) { this.owner = owner; }

	//Variables
	NavMeshAgent ownerNavMesh;

	const float distToArrive = 1.5f;

	bool Arrived(Vector3 destination)
	{
		bool hasArrived = false;
		float distToDestination = Vector3.Distance (owner.transform.position, destination);

		if (distToDestination <= distToArrive) {
			hasArrived = true;
		}

		return hasArrived;
	}

	public void Enter()
	{
		ownerNavMesh = owner.GetComponent<NavMeshAgent> ();
		ownerNavMesh.destination = new Vector3 (0, 0, 0);
		Debug.Log ("Entering wander state");
	}

	public void Execute()
	{
		if (Arrived (owner.GetComponent<NavMeshAgent>().destination)) {
			Debug.Log ("Hi im here");
		}
	}

	public void Exit()
	{
		Debug.Log ("Exiting wander state");
	}
}
