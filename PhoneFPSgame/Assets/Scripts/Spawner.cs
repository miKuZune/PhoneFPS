using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;

    public int numOfEnemiesToSpawn;

    float spawnTimer;
    const float timeTillNextSpawn = 1.5f;

    public void Spawn()
    {
        int enemyID = Random.Range(0, enemies.Length - 1);

        Instantiate(enemies[enemyID], transform.position, Quaternion.identity);

        numOfEnemiesToSpawn--;
    }

	// Use this for initialization
	void Start () {
        spawnTimer = timeTillNextSpawn;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0 && numOfEnemiesToSpawn > 0)
        {
            Spawn();
            spawnTimer = timeTillNextSpawn;
        }
	}
}
