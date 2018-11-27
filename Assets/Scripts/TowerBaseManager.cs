using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseManager : Singleton<TowerBaseManager>
{
    private List<GameObject> towerBases = new List<GameObject>();
    public GameObject clickedTower;
    [SerializeField]
    private GameObject startingBlock;
   
    // Use this for initialization
    void Start ()
    {
        CreateBases();
    }

    private void CreateBases()
    {
        float tileSize = startingBlock.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                PlaceTiles(tileSize, i, j, worldStart);
            }
        }
    }

    private void PlaceTiles(float tileSize, int i, int j, Vector3 WorldStart)
    {
        GameObject towerBase = Instantiate(startingBlock);
        towerBase.transform.position = new Vector3(WorldStart.x + (tileSize * i), WorldStart.y - (tileSize * j), 0);
        towerBases.Add(towerBase);
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public GameObject GetClickedTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, -Vector2.up);

        
        if (hit.collider != null)
        {
            for (int i = 0; i < towerBases.Count; i++)
            {
                if (towerBases[i].transform.position.x == hit.transform.position.x && towerBases[i].transform.position.y == hit.transform.position.y)
                {
                    clickedTower = towerBases[i];
                }
            }
        }
        return clickedTower;
    }
}
