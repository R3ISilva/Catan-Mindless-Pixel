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
        Vector2 hexUISpawnDuplicateLocation = transform.position;
        int t = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (selectedHexes[t])
                {
                    if(j == 0)
                    {
                        GameObject newHexUI = Instantiate(HexBase, hexUISpawnDuplicateLocation, transform.rotation);
                    }
                    else
                    {
                        GameObject newHexUI = Instantiate(HexPlain, hexUISpawnDuplicateLocation, transform.rotation);
                    }
                }

                hexUISpawnDuplicateLocation += new Vector2(0, hexHeight);
                t++;
            }

            hexUISpawnDuplicateLocation += new Vector2(hexWidth, .28f - (hexHeight * columns));

            if (!(i % 2 == 0))
            {
                hexUISpawnDuplicateLocation += new Vector2(0, -hexHeight);
            }
        }

    }
}
