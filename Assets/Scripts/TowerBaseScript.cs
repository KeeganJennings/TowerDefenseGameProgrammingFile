using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseScript : Singleton<TowerBaseScript>
{
    private GameObject selectedTower;
    private GameObject clickedTower;

    // Use this for initialization
    void Start ()
    {
        selectedTower = GameManager1.Instance.TowerPrefab;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void RemoveTowerMenu()
    {
        if (ButtonManager.Instance.ButtonWasClicked == true)
        {
            selectedTower = GameManager1.Instance.selectedTower;
            
            ChangeToTower();
            ButtonManager.Instance.ButtonWasClicked = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClickedTower();
            GameManager1.Instance.towerMenu.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameManager1.Instance.towerMenu.gameObject.SetActive(false);
        }
    }

    private void CheckClickedTower()
    {
        clickedTower = TowerBaseManager.Instance.GetClickedTower();
        if (clickedTower.tag == "4")
        {
            RemoveTowerMenu();
        }
    }


    private void ChangeToTower()
    {
        if(clickedTower != null)
        {
            Instantiate(selectedTower, new Vector2(clickedTower.transform.position.x, clickedTower.transform.position.y), Quaternion.identity);
            clickedTower.SetActive(false);
            GameManager1.Instance.towerMenu.gameObject.SetActive(false);
        }
    }
}
