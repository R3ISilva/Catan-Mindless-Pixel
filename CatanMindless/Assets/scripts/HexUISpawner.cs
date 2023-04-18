using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

namespace _LogicHex.LogicHex
{
    public class HexUISpawner : MonoBehaviour
    {
        public myHexProperties test;
        public GameObject HexUI;
        public List<LogicUIHex> hexProperties;
        private List<GameObject> spawnedHexUIs = new List<GameObject>();
        public int rows;
        public int columns;

        // Start is called before the first frame update
        void Start()
        {
            // Spawn a grid of HexUIs
            spawner();
        }

        // Spawn a grid of `rows` x `columns` HexUIs
        void spawner()
        {
            Vector2 hexUISpawnerLocation = transform.position;
            Vector2 hexUISpawnerInicialLocation = transform.position;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    GameObject newHexUI = Instantiate(HexUI, hexUISpawnerLocation, transform.rotation);
                    spawnedHexUIs.Add(newHexUI);

                    LogicUIHex newHexUIProperties = newHexUI.GetComponent<LogicUIHex>();

                    //SetHexProperties
                    newHexUIProperties.myHexProperties.Row = row;
                    newHexUIProperties.myHexProperties.Collumn = column;


                    hexUISpawnerLocation += new Vector2(0, .7f); // .7f valor da altura
                }

                if (row % 2 == 0)
                {
                    hexUISpawnerLocation += new Vector2(.6f, .35f - (.7f * columns));
                }
                else
                {
                    hexUISpawnerLocation += new Vector2(.6f, .35f - (.7f * columns) - .7f);
                }
            }
        }

        public List<HexProperties> Retrieve()
        {
            hexProperties = new List<LogicUIHex>();

            foreach (GameObject hexUI in spawnedHexUIs)
            {
                hexProperties.Add(hexUI.GetComponent<LogicUIHex>());
            }

            return hexProperties;
        }


    }

}
