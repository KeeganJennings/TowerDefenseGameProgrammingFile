using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 :  Singleton<GameManager1>
{

    //temp

    public GameObject[] towerPrefab;

    public GameObject selectedTower;
    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab[0];
        }
    }

    public Canvas towerMenu;

    // Use this for initialization
    void Start()
    {

        towerMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
