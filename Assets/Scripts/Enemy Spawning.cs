using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject basicEnemyPrefab;
    public GameObject hardEnemyPrefab;

    public float radius = 11f;
    public Vector2 center = Vector2.zero;
    public float spawnInterval = 2f;
    public float startTime = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), startTime, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Random angle
        float angle = Random.Range(0f, 360f); 

        // Find the points along the circle using trig
        Vector2 spawnPosition = center + new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;

        // Instantiate 
        Instantiate(hardEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
