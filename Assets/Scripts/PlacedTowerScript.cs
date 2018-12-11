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
    private float timeToAttack = 3f;
    private float nextAttack = 0f;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RemoveEmptyEnemies();
        RemoveEmptyProjectiles();
    }

    private void CheckForAttack()
    {
        if (enemies.Count >= 1)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (firedProjectiles.Count <= 0 && nextAttack >= timeToAttack)
        {
            firedProjectiles.Add(Instantiate(projectile, this.transform.position, Quaternion.identity, this.gameObject.transform));
            nextAttack = 0f; 
        }
        else
        {
            AttackCooldown();
        }
        
    }

    private void RemoveEmptyEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                if(enemies.Count >= 2)
                {
                    enemies.RemoveAt(i);
                }
            }
        }
    }

    private void RemoveEmptyProjectiles()
    {
        if(firedProjectiles.Count >= 1)
        {
            if (firedProjectiles[0] == null)
            {
                firedProjectiles.Clear();
            }
        }
    }

    private void AttackCooldown()
    {
        if(timeToAttack > nextAttack)
        {
            nextAttack = cooldown + nextAttack;
        }
    }

    private void OnTriggerEnter2D(Collider2D enemiesCollider)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy != null)
        {
            enemies.Add(enemy.gameObject);
            CheckForAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            enemies.Remove(enemy.gameObject);
        }

    }
}
