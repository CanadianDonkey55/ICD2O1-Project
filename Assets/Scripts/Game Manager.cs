using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Difficulty Timers")]
    [SerializeField] float hardEnemyCountdown = 60f;
    [SerializeField] float eliteEnemyCountdown = 180f;
    float currentTime = 0f;

    [Header("Harder Enemy Bools")]
    public bool hardEnemiesCanSpawn = false;
    public bool eliteEnemiesCanSpawn = false;

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
        // Increase time based on deltaTime
        currentTime += Time.deltaTime;
        
        if (currentTime >= hardEnemyCountdown)
        {
            hardEnemiesCanSpawn = true;
        }

        if (currentTime >= eliteEnemyCountdown)
        {
            eliteEnemiesCanSpawn = true;
        }
    }
}
