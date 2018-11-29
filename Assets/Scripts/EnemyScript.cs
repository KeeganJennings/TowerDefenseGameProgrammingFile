using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private int health;
    private float speed = 2f;
    public Transform[] currentSquareToMoveTo;
    private int currentSquare = 0;
    

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveAlongRoad();
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
        }
        

        if(transform.position.x == currentSquareToMoveTo[currentSquare].transform.position.x && transform.position.y == currentSquareToMoveTo[currentSquare].transform.position.y)
        {
            currentSquare++;
        }
    }

    private void DestroyAtEndOfRoad()
    {
        
    }
}
