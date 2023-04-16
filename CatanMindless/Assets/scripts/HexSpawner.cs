using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSpawner : MonoBehaviour
{
    public GameObject HexUISpawnerPreFab;
    public GameObject HexBase;
    public GameObject HexPlain;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)) //ACCEPT AND PRINT ARRAY
        {
            HexUISpawnerPreFab = GameObject.Find("HexUISpawner");
            SpawnDuplicate(HexUISpawnerPreFab.GetComponent<HexUISpawner>().Retrieve(), HexUISpawnerPreFab.GetComponent<HexUISpawner>().rows, HexUISpawnerPreFab.GetComponent<HexUISpawner>().columns);
        }
        
    }
    
    float hexHeight = .5f;
    float hexWidth = .64f;
    void SpawnDuplicate(List<LogicUIHex> hexPropertiesList, int rows, int columns)
    {
        Vector2 hexSpawnDuplicateLocation = transform.position;
        for (int row = 0; row < rows; row++)
        {
            
            for (int column = 0; column < columns; column++)
            {
                int hexIndex = row * columns + column;
                LogicUIHex hexProperties = hexPropertiesList[hexIndex];

                if (hexProperties.Selected)
                {
                    //Setting Properties
                    hexProperties.myIndex = hexIndex;
                    hexProperties.Sprite = "HexBase";

                    //spawning
                    GameObject newHex = Instantiate(HexBase, hexSpawnDuplicateLocation, transform.rotation);
                    newHex.GetComponent<LogicHex>().ConstructHex(hexProperties, rows, columns);
                }

                //move to the next spot in grid
                hexSpawnDuplicateLocation += new Vector2(0, hexHeight);
            }

            hexSpawnDuplicateLocation += new Vector2(hexWidth, .25f - (hexHeight * columns));

            if (!(row % 2 == 0))
            {
                hexSpawnDuplicateLocation += new Vector2(0, -hexHeight);
            }
        }

    }
}
