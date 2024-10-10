using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minDistance = 100f;
    public float spawnRadius = 200f;

    void Start()
    {
        InvokeRepeating("enemySpawner", 0f, 3f);
    }
    public void enemySpawner()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        GameObject enemySpam = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemySpam.gameObject.SetActive(true);
        enemySpam.transform.parent = transform;
    }

    public Vector2 GetRandomSpawnPosition()
    {
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-spawnRadius, spawnRadius);
            float randomY = Random.Range(-spawnRadius, spawnRadius);    
            randomPosition = new Vector2(randomX, randomY);
        }
        while (Mathf.Abs(randomPosition.x) < minDistance && Mathf.Abs(randomPosition.y) < minDistance);
        return randomPosition;
    }
}
