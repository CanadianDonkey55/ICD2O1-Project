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
    [SerializeField] float increasedHealth = 210f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentScore.ToString();

        // Increase time based on deltaTime
        currentTime += Time.deltaTime;
        
        if (currentTime >= hardEnemyCountdown)
        {
            hardEnemiesCanSpawn = true;
        }

        if (currentTime >= eliteEnemyCountdown)
        {
            eliteEnemiesCanSpawn = true;
            spawner.basicEnemySpawnChance = spawner.lowerBasicEnemySpawnChance;
        }
    }
}
