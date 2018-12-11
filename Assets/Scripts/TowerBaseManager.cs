using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseManager : Singleton<TowerBaseManager>
{
    private List<GameObject> towerBases = new List<GameObject>();
    public GameObject clickedTower;

    private TextAsset mapLayout;
    private string mapLayoutText;

    [SerializeField]
    private GameObject[] startingBlock = new GameObject[5];

   
    // Use this for initialization
    void Start ()
    {
        mapLayout = (TextAsset)Resources.Load("LevelLayout", typeof(TextAsset));
        mapLayoutText = mapLayout.text;
        mapLayoutText = mapLayoutText.Replace("\n", ".");
        CreateBases();
    }

    private void CreateBases()
    {
        float tileSize = startingBlock[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        int length = 0;
        int height = 0;
        MapLoop(tileSize, worldStart, ref length, ref height);
    }

    private void MapLoop(float tileSize, Vector3 worldStart, ref int length, ref int height)
    {
        for (int i = 0; i < mapLayoutText.Length; i++)
        {
            if (mapLayoutText[i] == '0' || mapLayoutText[i] == '1' || mapLayoutText[i] == '2' || mapLayoutText[i] == '3' || mapLayoutText[i] == '4')
            {
                
                string s = mapLayoutText[i].ToString();
                int tile = int.Parse(s);
                PlaceTiles(tileSize, length, height, worldStart, tile);

                length++;
                if (length >= 17)
                {
                    height++;
                    length = 0;
                }
            }
        }
    }

    private void PlaceTiles(float tileSize, int i, int j, Vector3 WorldStart, int placeTile)
    {
        GameObject towerBase = Instantiate(startingBlock[placeTile]);
        towerBase.gameObject.tag = placeTile.ToString();
        towerBase.transform.position = new Vector3(WorldStart.x + (tileSize * i), WorldStart.y - (tileSize * j), 0);
        towerBases.Add(towerBase);
        towerBase.transform.parent = transform;
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
