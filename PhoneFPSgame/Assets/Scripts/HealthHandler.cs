using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour {

    public int health;

    public void TakeHealth(int healthToTake)
    {
        health -= healthToTake;

        CheckForDeath();
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;

        CheckForDeath();
    }

    public int GetHealth()
    {
        return health;
    }

	
    void CheckForDeath()
    {
        if(health <= 0)
        {
            if(gameObject.tag != "Player")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().EnemyKilled(20);
                Destroy(this.gameObject);
            }
            
        }
    }

}
