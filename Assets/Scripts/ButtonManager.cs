﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager> {

    public Button RedTowerButton;
    public Button BlueTowerButton;
    public Button YellowTowerButton;
    public bool ButtonWasClicked = false;

	// Use this for initialization
	void Start () {
		if(RedTowerButton != null)
        {
            Button btn = RedTowerButton.GetComponent<Button>();
            btn.onClick.AddListener(AddRedTower);
        }
        if (BlueTowerButton != null)
        {
            Button btn = BlueTowerButton.GetComponent<Button>();
            btn.onClick.AddListener(AddBlueTower);
        }
        if (YellowTowerButton != null)
        {
            Button btn = YellowTowerButton.GetComponent<Button>();
            btn.onClick.AddListener(AddYellowTower);
        }
    }

    private void AddYellowTower()
    {
        GameManager1.Instance.YellowTower();
        ButtonWasClicked = true;
    }

    private void AddBlueTower()
    {
        GameManager1.Instance.BlueTower();
        ButtonWasClicked = true;
    }

    private void AddRedTower()
    {
        GameManager1.Instance.RedTower();
        ButtonWasClicked = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
