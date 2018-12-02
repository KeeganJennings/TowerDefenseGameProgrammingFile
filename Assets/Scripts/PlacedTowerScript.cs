using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedTowerScript : Singleton<PlacedTowerScript>
{
    public List<GameObject> enemies = new List<GameObject>();
    public  List<GameObject> firedProjectiles = new List<GameObject>();
    public GameObject projectile;
    private float cooldown = 1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RemoveEmptyPlaces();
    }

    private void CheckForAttack()
    {
        if (enemies.Count > 1)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (firedProjectiles.Count <= 1 && cooldown <= 0)
        {
            firedProjectiles.Add(Instantiate(projectile, this.transform.position, Quaternion.identity, this.gameObject.transform));
            enemies[0].GetComponent<EnemyScript>().TakeDamage();
            firedProjectiles.Add(projectile);
            cooldown = .5f;
        }
        else
        {
            AttackCooldown();
        }
        
    }

    private void RemoveEmptyPlaces()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
    }

    private void AttackCooldown()
    {
        cooldown = cooldown - Time.deltaTime;

        if(cooldown <= 0)
        {
            Attack();
        }
        else
        {
            Debug.Log("Cooldown: " + cooldown);
        }
    }

    private void OnTriggerEnter2D(Collider2D enemiesCollider)
    {
        //Debug.Log("OnTriggerStay");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy != null)
        {
            enemies.Add(enemy.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckForAttack();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy != null)
        {
            enemies.Remove(enemy.gameObject);
        }
             
    }
}
