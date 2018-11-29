using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private int health;
    private float speed = 2f;
    public Transform[] currentSquareToMoveTo;
    private GameObject homeBaseSquare;
    private int currentSquare = 0;

    private Collider enemyCollider = SpawnerScript.Instance.enemies[0].GetComponent<Collider>();
    
    

    // Use this for initialization
    void Start ()
    {
        homeBaseSquare = GameObject.FindGameObjectWithTag("2");
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveAlongRoad();
        DestroyAtEndOfRoad();
	}

    private void CheckIfDead()
    {
        if(health <= 0)
        {
            
        }
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
        Collider homeBaseCollider = homeBaseSquare.GetComponent<Collider>();

        if(enemyCollider != null)
        {
            Debug.Log("Enemy is fine!");
        }
        if(homeBaseCollider != null)
        {
            Debug.Log("Home base collider is fine!");
        }
        if(enemyCollider.bounds.Intersects(homeBaseCollider.bounds))
        {
            Destroy(this);
        }
        
    }
}
