using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedTowerScript : Singleton<PlacedTowerScript>
{
    public List<GameObject> enemies = new List<GameObject>();
    private List<GameObject> firedProjectiles = new List<GameObject>();
    public GameObject projectile;
    private float cooldown = 1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void Attack()
    {
        if(enemies.Count > 0 && firedProjectiles.Count <= 10 && cooldown <= 0)
        {
            firedProjectiles.Add(Instantiate(projectile, this.transform.position, Quaternion.identity));
            AttackCooldown();
        }
        else
        {
            AttackCooldown();
        }
    }

    private void AttackCooldown()
    {
        cooldown = cooldown - Time.deltaTime;

        if(cooldown <= 0)
        {
            Attack();
        }
    }

    private void OnTriggerStay2D(Collider2D enemiesCollider)
    {
        Debug.Log("OnTriggerStay");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy != null)
        {
            enemies.Add(enemiesCollider.gameObject);
            Attack();

        }
    }
}
