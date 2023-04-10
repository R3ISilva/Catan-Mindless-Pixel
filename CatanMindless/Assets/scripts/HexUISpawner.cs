using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class HexUISpawner : MonoBehaviour
{
    public GameObject HexUI;
    public List<bool> selectedHexes;
    private List<GameObject> spawnedHexUIs = new List<GameObject>();
    public int rows;
    public int columns;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn a grid of HexUIs
        spawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn a grid of `rows` x `columns` HexUIs
    void spawner()
    {
        Vector2 hexUISpawnerLocation = transform.position;
        Vector2 hexUISpawnerInicialLocation = transform.position;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject newHexUI = Instantiate(HexUI, hexUISpawnerLocation, transform.rotation);
                spawnedHexUIs.Add(newHexUI);
                hexUISpawnerLocation += new Vector2(0, .7f); // .7f valor da altura
            }
            
            if (i % 2 == 0)
            {
                hexUISpawnerLocation += new Vector2(.6f, .35f - (.7f * columns));
            }
            else
            {
                hexUISpawnerLocation += new Vector2(.6f, .35f - (.7f * columns) - .7f);
            }
        }
    }

    public List <bool> Retrieve()
    {
        selectedHexes = new List<bool>();

        foreach (GameObject hexUI in spawnedHexUIs)
        {
            selectedHexes.Add(hexUI.GetComponent<LogicUIHex>().Selected);
        }

        return selectedHexes;
    }

   
}
