using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private GameObject enemyPrefab;
    private float rowSpacing = 2.0f;
    private int level = 0;
    
    private void Start()
    {
    }

    public void SpawnEnemiesForLevel(int enemyCount)
    {

        //make enemies line in 2 rows
        int enemiesInFirstRow = enemyCount / 2;
        int enemiesInSecondRow = enemyCount - enemiesInFirstRow;


        Vector3 startPos = new Vector3(-3.77f, 1.3f, -2);
        Quaternion enemyRotation = Quaternion.Euler(270, 155.6f, 0); 

        for (int i = 0; i < enemiesInFirstRow; i++)
        {
            Vector3 spawnPosition = startPos + new Vector3(i, 0, 0) * rowSpacing;
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, enemyRotation);
            // Add the enemy to the list
            enemyList.Add(enemy);
        }

        for (int i = 0; i < enemiesInSecondRow; i++)
        {
            Vector3 spawnPosition = startPos + new Vector3(i, 1, 0) * rowSpacing;
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, enemyRotation);
            // Add the enemy to the list
            enemyList.Add(enemy);
        }
    }
    
    public void DestroyAllEnemies()
    {
        foreach (GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }

        // Clear the list after destroying all enemies
        enemyList.Clear();
    }

    private void Update()
    {
    }

   
   
}