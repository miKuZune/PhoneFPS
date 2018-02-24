using System.Collections;
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

        UIManager UI = GameObject.Find("UImanager").GetComponent<UIManager>();
        UI.UpdateEnemiesLeft(enemiesInLevel);
        UI.UpdateEnemiesKilled(enemiesKilled);

        score += scoreToAdd;


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
        enemiesToSpawnNextRound = 10 * (round);
        UIManager UI = GameObject.Find("UImanager").GetComponent<UIManager>();
        UI.UpdateRound(round);
        UI.UpdateEnemiesLeft(enemiesInLevel);
        Debug.Log(round);
    }

	// Use this for initialization
	void Start () {
        enemiesToSpawnNextRound = 10;

        UIManager UI = GameObject.Find("UImanager").GetComponent<UIManager>();
        UI.UpdateEnemiesLeft(enemiesInLevel);
        UI.UpdateEnemiesKilled(enemiesKilled);
        UI.UpdateRound(round );

        
	}
	
	// Update is called once per frame
	void Update () {
        if (enemiesInLevel <= 0)
        {
            NewRound();
        }
    }        
}
