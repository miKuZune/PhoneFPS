using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explode : MonoBehaviour,IState {

	GameObject owner;
	public Explode(GameObject owner) { this.owner = owner; }

	//Variables
	GameObject player;

	float timeWaited = 0;

	const float timeTillExplosion = 1.5f;
	const float distToDealDamage = 5.0f;
    bool hasExploded = false;


	void DoExplode()
	{
		float distToPlayer = Vector3.Distance (owner.transform.position, player.transform.position);
		if (distToPlayer <= distToDealDamage) 
		{
			player.GetComponent<HealthHandler> ().TakeHealth (owner.GetComponent<Runners> ().damageToDeal);
            GameObject.Find("UImanager").GetComponent<UIManager>().ShowDamageIndicator();
		}
        owner.GetComponent<HealthHandler>().TakeHealth(20000);
	}

	public void Enter()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		Debug.Log ("Exploding");
	}
	public void Execute()
	{
		timeWaited += Time.deltaTime;

		if (timeWaited > timeTillExplosion && !hasExploded)
		{
            hasExploded = true;
			DoExplode ();
		}
	}
	public void Exit()
	{
		Debug.Log ("???");
	}
}
