using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool hasWon = false;
    public bool bossDefeated = false;

    [Header("Scoring")]
    public float currentScore = 0;
    [SerializeField] float winScore = 500f;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject winScreen;

    [Header("Difficulty Timers")]
    [SerializeField] float hardEnemyCountdown = 60f;
    [SerializeField] float eliteEnemyCountdown = 180f;
    [SerializeField] float bossEnemyPointsNeeded = 450f;
    float currentTime = 0f;

    [Header("Enemy Difficulty")]
    public bool hardEnemiesCanSpawn = false;
    public bool eliteEnemiesCanSpawn = false;
    public bool bossCanSpawn = false;
    [SerializeField] EnemySpawning spawner;

    [Header("Upgrades")]
    [SerializeField] ImmuneSystem immuneSystem;
    [SerializeField] float doubleShotCountdown = 100f;
    [SerializeField] float wideShotCountdown = 200f;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
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

        // If the amount of time the game has been running for is higher than the wideShotCountdown, turn on wideShot
        if (currentTime >= wideShotCountdown)
        {
            immuneSystem.wideShot = true;
        }

        if (currentScore >= bossEnemyPointsNeeded && !bossCanSpawn && !spawner.bossExists)
        {
            bossCanSpawn = true;
        }

        // Check for win
        if (currentScore >= winScore && !hasWon && bossDefeated)
        {
            winScreen.SetActive(true);
            immuneSystem.health += immuneSystem.increasedHealth;
            immuneSystem.healthBar.maxValue = immuneSystem.healthBar.maxValue + immuneSystem.increasedHealth;
            hasWon = true;
            Time.timeScale = 0;
        }
    }
}