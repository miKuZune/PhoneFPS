using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runners : MonoBehaviour {

	StateMachine SM = new StateMachine();
	GameObject player;
	const float closeEnough = 1.5f;

	public int damageToDeal;

	bool isExploding;

	bool IsCloseToPlayer()
	{
		bool isCloseEnough = false;
		float distToPlayer = Vector3.Distance (transform.position, player.transform.position);
		if (distToPlayer <= closeEnough)
		{
			isCloseEnough = true;	
		}

		return isCloseEnough;
	}


	// Use this for initialization
	void Start () {
		isExploding = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		SM.ChangeState (new RunAtPlayer (this.gameObject));
	}
	
	// Update is called once per frame
	void Update () {
		if (IsCloseToPlayer () && !isExploding) {
			SM.ChangeState (new Explode (this.gameObject));
			isExploding = true;
		}

		SM.Update ();
	}
}
