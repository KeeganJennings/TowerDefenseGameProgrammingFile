using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Singleton<EnemyScript>
{

    private int health = 10;
    private float speed = 2f;
    public Transform[] currentSquareToMoveTo;
    private GameObject homeBaseSquare;
    private int currentSquare = 0;

    private BoxCollider2D enemyCollider;
    
    

    // Use this for initialization
    void Start ()
    {
        homeBaseSquare = GameObject.FindGameObjectWithTag("2");
        enemyCollider = SpawnerScript.Instance.spawnedEnemy.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveAlongRoad();
        DestroyAtEndOfRoad();
    }

    private bool CheckIfDead()
    {

        bool dead = false;
        if(health <= 0)
        {
            dead = true;
            Destroy(this.gameObject, .5f);
            SpawnerScript.Instance.enemies.Remove(this.gameObject);
            PlacedTowerScript.Instance.enemies.Remove(this.gameObject);
        }
        
        return dead;
    }

    public void TakeDamage()
    {
        health = health - 6;
        Debug.Log(health);
    }

    private void MoveAlongRoad()
    {
        if (currentSquare <= currentSquareToMoveTo.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(currentSquareToMoveTo[currentSquare].transform.position.x,
                currentSquareToMoveTo[currentSquare].transform.position.y), speed * Time.deltaTime);
            if (transform.position.x == currentSquareToMoveTo[currentSquare].transform.position.x && transform.position.y == currentSquareToMoveTo[currentSquare].transform.position.y)
            {
                currentSquare++;
                if (currentSquare > currentSquareToMoveTo.Length)
                {
                    currentSquare = currentSquareToMoveTo.Length;
                }
            }
        }
    }

    private void DestroyAtEndOfRoad()
    {
        BoxCollider2D homeBaseCollider = homeBaseSquare.GetComponent<BoxCollider2D>();
        bool checkedDead = CheckIfDead();
        if (checkedDead == false)
        {
            if (enemyCollider.bounds.Intersects(homeBaseCollider.bounds))
            {
                Destroy(this.gameObject, .5f);
                health = 0;
                //Debug.Log("Destroyed");
                SpawnerScript.Instance.enemies.Remove(this.gameObject);
            }         
        }
    }
}
