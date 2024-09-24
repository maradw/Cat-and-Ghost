using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset txtMap;
    public string[] arrayMap;
    public string[] arrayRowMap;
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject newwallPrefab;
    public GameObject newfloorPrefab;
    public float _distanceX;
    public float _distanceY;
    public Vector2 initialPositionToCreate;
    // Start is called before the first frame update
    void Start()
    {
        arrayMap = txtMap.text.Split("\n");
        Vector2 positionForBlocks;
        for (int i = 0; i < arrayMap.Length; i++)
        {
            arrayRowMap = arrayMap[i].Split(";");
            for (int j = 0; j < arrayRowMap.Length; j++)
            {
                positionForBlocks = new Vector2(initialPositionToCreate.x + _distanceX * j, initialPositionToCreate.y - _distanceY * i);

                if (arrayRowMap[j] == "4")
                {
                    Instantiate(wallPrefab, positionForBlocks, transform.rotation);
                }
                else if (arrayRowMap[j] == "8")
                {
                    Instantiate(floorPrefab, positionForBlocks, transform.rotation);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
