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
    float hexWidth = .63f;
    void SpawnDuplicate(List<bool> selectedHexes, int rows, int columns)
    {
        Vector2 hexSpawnDuplicateLocation = transform.position;
        for (int row = 0; row < rows; row++)
        {
            
            for (int column = 0; column < columns; column++)
            {
                int x = row * columns + column;
                if (selectedHexes[x])
                {
                    GameObject newHex = Instantiate(HexBase, hexSpawnDuplicateLocation, transform.rotation);
                    newHex.GetComponent<LogicHex>().ConstructHex(selectedHexes, x, row, column, rows, columns);
                }

                hexSpawnDuplicateLocation += new Vector2(0, hexHeight);
            }

            hexSpawnDuplicateLocation += new Vector2(hexWidth, .28f - (hexHeight * columns));

            if (!(row % 2 == 0))
            {
                hexSpawnDuplicateLocation += new Vector2(0, -hexHeight);
            }
        }

    }
}
