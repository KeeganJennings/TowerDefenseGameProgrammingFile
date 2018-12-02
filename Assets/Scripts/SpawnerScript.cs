using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : Singleton<SpawnerScript>
{
    public List<GameObject> enemies = new List<GameObject>();
    private float numberOfEnemiesToSpawn = 15;
    private float timeWave = 5f;
    private float timeEnemy = 1f;
    public GameObject spawnedEnemy;
    public GameObject spawnBlock;
    public GameObject enemyPrefab;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        SpawnWavesDelay();
    }

    private void SpawnWavesDelay()
    {
        

        timeWave = timeWave - Time.deltaTime;

        if (timeWave <= 0 || timeEnemy != 1f)
        {
            SpawnEnemyDelay();
            timeWave = 5f;
        }
        else
        {
            //Debug.Log("Waiting to spawn");
            //Debug.Log(timeWave);
        }
    }
    private void SpawnEnemyDelay()
    {
        timeEnemy = timeEnemy - Time.deltaTime;

        if(timeEnemy <= 0)
        {
            timeEnemy = .75f;
            SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        if(enemies.Count <= numberOfEnemiesToSpawn)
        {
            spawnedEnemy = Instantiate(enemyPrefab, spawnBlock.transform.position, Quaternion.identity);
            enemies.Add(spawnedEnemy);
            SpawnEnemyDelay();
            
        }
        //Debug.Log(enemies.Count);
    }
}
