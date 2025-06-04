using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Prefabs")]
    public GameObject basicEnemyPrefab;
    public GameObject hardEnemyPrefab;
    public GameObject eliteEnemyPrefab;
    public GameObject bossEnemyprefab;
    public GameObject currentSpawn;

    [Header("Spawn Settings")]
    public float radius = 11f;
    private Vector2 center;
    public float spawnInterval = 2f;
    public float reducedSpawnInterval = 1.5f;
    public float startTime = 3f;

    [Header("Spawn Chances")]
    [Range(0f, 75f)]
    public int basicEnemySpawnChance = 25;
    [Range(0f, 75f)]
    public int hardEnemySpawnChance = 50;
    [Range(0f, 75f)]
    public int eliteEnemySpawnChance = 75;
    [Range(0f, 75f)]
    public int lowerBasicEnemySpawnChance = 18;

    void Start()
    {
        currentSpawn = basicEnemyPrefab;
        center = transform.position;
        InvokeRepeating(nameof(SpawnEnemy), startTime, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Random angle
        float angle = Random.Range(0f, 360f); 

        // Find the points along the circle using trig
        Vector2 spawnPosition = center + new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;

        // Randomize which enemy type will spawn
        RandomSpawn();

        // Instantiate if no boss spawning
        currentSpawn.GetComponent<Enemy>().gameManagerObject = gameManager.gameObject;
        if (!gameManager.bossCanSpawn) 
        { 
            Instantiate(currentSpawn, spawnPosition, Quaternion.identity);
        }

        // If the boss can spawn, instantiate the boss enemy prefab
        if (gameManager.bossCanSpawn)
        {
            Instantiate(currentSpawn, spawnPosition, Quaternion.identity);
            gameManager.bossCanSpawn = false; // Reset the boss spawn flag after spawning
        }
    }

    private void RandomSpawn()
    {
        int randomValue = Random.Range(0, eliteEnemySpawnChance);

        if (gameManager.bossCanSpawn)
        {
            currentSpawn = bossEnemyprefab;
        }
        else if (randomValue <= basicEnemySpawnChance)
        {
            currentSpawn = basicEnemyPrefab;
        }
        else if (randomValue <= hardEnemySpawnChance && randomValue > basicEnemySpawnChance && gameManager.hardEnemiesCanSpawn)
        {
            currentSpawn = hardEnemyPrefab;
        }
        else if (randomValue <= eliteEnemySpawnChance && randomValue > hardEnemySpawnChance && gameManager.eliteEnemiesCanSpawn)
        {
            currentSpawn = eliteEnemyPrefab;
        }
    }
}