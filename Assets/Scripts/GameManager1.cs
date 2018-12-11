using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 :  Singleton<GameManager1>
{

    //temp
    private int baseHealth = 50;
    public GameObject[] towerPrefab;

    public GameObject selectedTower;
    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab[0];
        }
    }

    public Canvas baseHealthUI;
    public Canvas towerMenu;
    public GameObject baseHealthUIText;

    // Use this for initialization
    void Start()
    {
        baseHealthUI.gameObject.SetActive(true);
        towerMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        baseHealthUIText.GetComponent<UnityEngine.UI.Text>().text = "Lives left: " + baseHealth;
    }

    public void SubtractHealth()
    {
        baseHealth--;
    }

    public void YellowTower()
    {
        selectedTower = towerPrefab[0];
    }

    public void RedTower()
    {
        selectedTower = towerPrefab[1];
    }

    public void BlueTower()
    {
        selectedTower = towerPrefab[2];
    }
}
