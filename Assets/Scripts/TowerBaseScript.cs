using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseScript : MonoBehaviour
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
        if(ButtonManager.Instance.ButtonWasClicked == true)
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
            Debug.Log("Mouse was clicked");
            GameManager1.Instance.towerMenu.gameObject.SetActive(true);

        }
        if(Input.GetMouseButtonDown(1))
        {
            GameManager1.Instance.towerMenu.gameObject.SetActive(false);
        }
            
    }

    

    private void ChangeToTower()
    {
        Debug.Log("Place a tower");
        clickedTower = TowerBaseManager.Instance.GetClickedTower();
        Instantiate(selectedTower, new Vector2(clickedTower.transform.position.x, clickedTower.transform.position.y), Quaternion.identity);
        this.gameObject.SetActive(false);
        GameManager1.Instance.towerMenu.gameObject.SetActive(false);
    }
}
