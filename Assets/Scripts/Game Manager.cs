using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScore = 0;
    [SerializeField] TMP_Text scoreText;

    [Header("Difficulty Timers")]
    [SerializeField] float hardEnemyCountdown = 60f;
    [SerializeField] float eliteEnemyCountdown = 180f;
    float currentTime = 0f;

    [Header("Enemy Difficulty")]
    public bool hardEnemiesCanSpawn = false;
    public bool eliteEnemiesCanSpawn = false;
    [SerializeField] EnemySpawning spawner;

    [Header("Upgrades")]
    [SerializeField] ImmuneSystem immuneSystem;
    [SerializeField] float doubleShotCountdown = 100f;
    [SerializeField] float wideShotCountdown = 200f;
    [SerializeField] float increasedHealthCountdown = 210f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure the score text is always showing the current score
        scoreText.text = currentScore.ToString();

        // Increase time based on deltaTime
        currentTime += Time.deltaTime;
        
        // If the amount of time the game has been running for is higher than the hardEnemyCountdown, allow hard enemies to spawn
        if (currentTime >= hardEnemyCountdown)
        {
            hardEnemiesCanSpawn = true;
        }

        // If the amount of time the game has been running for is higher than the eliteEnemyCountdown, allow elite enemies to spawn
        if (currentTime >= eliteEnemyCountdown)
        {
            eliteEnemiesCanSpawn = true;
            spawner.basicEnemySpawnChance = spawner.lowerBasicEnemySpawnChance;
        }

        // If the amount of time the game has been running for is higher than the doubleShotCountdown, turn on doubleShot and increase the enemy spawn frequency
        if (currentTime >= doubleShotCountdown)
        {
            immuneSystem.doubleShot = true;
            spawner.spawnInterval = spawner.reducedSpawnInterval;
        }

        // If the amount of time the game has been running for is higher than the increasedHealthCountdown, increase player health
        if (currentTime >= increasedHealthCountdown)
        {
            immuneSystem.health = immuneSystem.increasedHealth;
        }
    }
}
