using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    private float speed = 1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveTowardsTheFarthestEnemy();
	}

    private void OnTriggerEnter(Collider collider)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy != null)
        {
            EnemyScript.Instance.TakeDamage();
            Destroy(this.gameObject, .1f);
            PlacedTowerScript.Instance.firedProjectiles.RemoveAt(0);
        }
    }

    private void MoveTowardsTheFarthestEnemy()
    {
        this.transform.position = Vector2.MoveTowards(PlacedTowerScript.Instance.enemies[1].transform.position, this.transform.position, speed * Time.deltaTime);
    }
}
