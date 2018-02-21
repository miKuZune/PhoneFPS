﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] spawnPoints;

    //Variables to hold things within the level
    int enemiesInLevel;
    int enemiesKilled;
    int score;
    int round;

    //variables to calculate enemies for a new round
    int enemiesToSpawnNextRound;
        

    public void EnemyKilled(int scoreToAdd)
    {
        enemiesInLevel--;
        enemiesKilled++;
        score += scoreToAdd;
        Debug.Log(enemiesInLevel);
    }
    void NewRound()
    {
        for(int i = 0; i < enemiesToSpawnNextRound; i++)
        {
            int spawnPointID = Random.Range(0, spawnPoints.Length);
            spawnPoints[spawnPointID].GetComponent<Spawner>().numOfEnemiesToSpawn++;
            enemiesInLevel++;
        }
        round++;
        enemiesToSpawnNextRound = 10 * round;
    }

	// Use this for initialization
	void Start () {
        enemiesToSpawnNextRound = 10;
        round = 1;

        NewRound();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemiesInLevel <= 0)
        {
            NewRound();
        }
	}
}