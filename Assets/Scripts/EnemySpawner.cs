using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject merekPrefab;
    [SerializeField] private GameManagerCat _secondGameManager;
    [SerializeField] private GameObject _newKilla;
    [SerializeField]int quantity = 0;
    public TextMeshProUGUI currentGhosts;

    private List<Enemy> enemies = new List<Enemy>();

    void CreateMerekEnemies()
    {
        float x = Random.Range(-7.6f, 8f);
        float y = Random.Range(-4.3f, 4.3f);
        float mTime = Random.Range(0.3f, 0.9f);
        Vector2 merekPosition = new Vector2(x, y);

        GameObject newMerek = Instantiate(merekPrefab, merekPosition, transform.rotation);
        Enemy enemy = newMerek.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemies.Add(enemy);
            enemy.OnEliminated += () => RemoveEnemy(enemy);
        }

        quantity++;
        Invoke("CreateMerekEnemies", mTime);
    }

    void RemoveEnemy(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            quantity--;
        }
    }

    private void Update()
    {
        currentGhosts.text = "ghosts: " + quantity;
    }
    public int Getquantity()
    {
        return quantity;
    }
    void Start()
    {
        float mTime = Random.Range(0.8f, 0.1f);
        Invoke("CreateMerekEnemies", mTime);
        //quantity++;
    }
    void OnEnable()
    {
       // Enemy.OnEliminated += CurrentGhosts;
    }
    private void OnDisable()
    {
       // Enemy.OnEliminated -= CurrentGhosts;
    }
    
    
    public void CurrentGhosts()
    {
        quantity = quantity-1;
    }


}
