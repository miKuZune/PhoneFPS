using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector3 direction = Vector3.zero;
    public float speed = 1.5f;

    public int damage = 20;

    const float timeToLive = 7.5f;
    float timeAlive = 0;
    public GameObject owner;

	// Use this for initialization
	void Start () {
        if(owner == null)
        {
            direction = Camera.main.transform.forward;
            transform.rotation = Camera.main.transform.rotation;
        }
        else
        {

        }
        
	}
	
    void CheckForDespawn()
    {
        if(timeAlive > timeToLive)
        {
            Destroy(this.gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        transform.position += direction * speed * Time.deltaTime;



        CheckForDespawn();
        timeAlive += Time.deltaTime;
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject == owner)
        {
            return;
        }
        if(coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Player")
        {
            if(coll.GetComponent<HealthHandler>())
            {
                coll.GetComponent<HealthHandler>().TakeHealth(damage);
                if(coll.gameObject.tag == "Player")
                {
                    GameObject.Find("UImanager").GetComponent<UIManager>().ShowDamageIndicator();
                }
            }
            else
            {
                Debug.Log("No health handler found");
            }
            
            Destroy(this.gameObject);
        }
    }
}
