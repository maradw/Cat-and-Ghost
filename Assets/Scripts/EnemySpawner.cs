using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject merekPrefab;
    [SerializeField] private GameManager _secondGameManager;
    [SerializeField] private GameObject _newKilla;

    void Start()
    {
        float mTime = Random.Range(0.5f, 0.1f);
        Invoke("CreateMerekEnemies", mTime);
    }
    void CreateMerekEnemies()
    {
        float x = Random.Range(-7.98f, 8f);
        float y = Random.Range(-4.3f, 4.3f);
        float mTime = Random.Range(0.3f, 0.9f);
        Vector2 merekPosition = new Vector2(x, y);
        GameObject newMerek = Instantiate(merekPrefab, merekPosition, transform.rotation);

        
        Invoke("CreateMerekEnemies", mTime);
    }
    

    void Update()
    {
        
    }
}
