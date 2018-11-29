using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : Singleton<SpawnerScript>
{
    public List<GameObject> enemies = new List<GameObject>();
    private float numberOfEnemiesToSpawn = 15;

    public GameObject spawnBlock;
    public GameObject enemyPrefab;

    // Use this for initialization
    void Start ()
    {
        SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update ()
    {

        

    }

    private void SpawnDelay()
    {
        var time = 15.1;

        time -= Time.deltaTime;

        if (time <= 0)
        {
            SpawnEnemies();
            time = 15.1;
            SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        for(int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnBlock.transform.position, Quaternion.identity);
            enemies.Add(spawnedEnemy);
        }
    }
}
