using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    private float speed = 10f;
    private BoxCollider2D enemyCollider;
    private CircleCollider2D towerCollider;

	// Use this for initialization
	void Start ()
    {
        towerCollider = this.transform.parent.GetComponent<PlacedTowerScript>().GetComponent<CircleCollider2D>();
	}

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTheFarthestEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        for (int i = 0; i < PlacedTowerScript.Instance.enemies.Count; i++)
        {
            if (PlacedTowerScript.Instance.enemies[i] != null)
            {
                enemyCollider = PlacedTowerScript.Instance.enemies[i].GetComponent<BoxCollider2D>();
                if (towerCollider.bounds.Intersects(enemyCollider.bounds))
                {
                    if (enemyCollider.bounds.Intersects(this.GetComponent<CircleCollider2D>().bounds))
                    {
                        this.transform.parent.GetComponent<PlacedTowerScript>().enemies[i].gameObject.GetComponent<EnemyScript>().TakeDamage();
                        this.transform.parent.GetComponent<PlacedTowerScript>().firedProjectiles.Remove(this.gameObject);
                        Destroy(this.gameObject, .1f);
                        i = PlacedTowerScript.Instance.enemies.Count + 1;
                    }
                }
                else
                {
                    Destroy(this.gameObject, .1f);
                }
            }
        }
    }

    private void MoveTowardsTheFarthestEnemy()
    {
        int MoveTowardsThisEnemy = 0;
        for(int i = 0; i < PlacedTowerScript.Instance.enemies.Count; i++)
        {
            if(PlacedTowerScript.Instance.enemies[i] != null)
            {
                MoveTowardsThisEnemy = i;
                i = PlacedTowerScript.Instance.enemies.Count + 1;
            }
        }

        if(PlacedTowerScript.Instance.enemies[MoveTowardsThisEnemy] != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, PlacedTowerScript.Instance.enemies[MoveTowardsThisEnemy].transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject, .1f);
        }
    }
}
