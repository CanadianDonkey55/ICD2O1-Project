using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health = 2f;
    public float speed = 2f;
    public float damage = 1f;
    [SerializeField] bool isBoss = false;

    [Header("Scorekeeping")]
    public float points = 1;
    public GameObject gameManagerObject;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to the gameManager
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the center(where the immuneSystem is)
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);

        // When the health reaches 0, give the player some points and destroy the enemy
        if (health <= 0)
        {
            if (isBoss) gameManager.bossDefeated = true;
            gameManager.currentScore += points;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Take damage on collision with Cell and destroy the Cell
        if (collision.tag == "Cell")
        {
            health -= collision.GetComponent<Cell>().damage;
            Destroy(collision.gameObject);
        }

        // Deal damage to the ImmuneSystem on collision and destroy this enemy
        if (collision.tag == "ImmuneSystem")
        {
            collision.GetComponent<ImmuneSystem>().health -= damage;
            Destroy(gameObject);
        }
    }
}
