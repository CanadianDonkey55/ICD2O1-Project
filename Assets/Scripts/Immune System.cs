using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImmuneSystem : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform wideBulletSpawnPoint1;
    public Transform wideBulletSpawnPoint2;

    [Header("Health")]
    public float health = 10f;
    public float increasedHealth = 5f;
    public Slider healthBar;

    [Header("Upgrades")]
    public bool doubleShot = false;
    public float secondShotDelay = 0.3f;
    public bool wideShot = false;

    // Start is called before the first frame update
    void Start()
    {
        // Makes sure that the healthbar can always display the current health
        healthBar.maxValue = health;
    }

    // Update is called once per frame
    private void Update()
    { 
        Rotate();

        // Always have the healthBar display the current health
        healthBar.value = health;

        // Check for mouse click and clone the bullet prefab
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn a second bullet if doubleShot is enabled
            if (doubleShot)
            {
                StartCoroutine(DoubleShotCoroutine(bulletSpawnPoint));

                // Spawn cells at two more locations if wideShot is enabled
                if (wideShot)
                {
                    StartCoroutine(DoubleShotCoroutine(wideBulletSpawnPoint1));
                    StartCoroutine(DoubleShotCoroutine(wideBulletSpawnPoint2));
                }
            }
            else
            {
                Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            }
        }

        // Check for death
        if (health <= 0) SceneManager.LoadScene(2);
    }

    private void Rotate()
    {
        // Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction from object to mouse
        Vector3 direction = mousePos - transform.position;

        // Calculate angle in degrees and rotate the object
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    // Coroutine for double shot
    private IEnumerator DoubleShotCoroutine(Transform spawnPosition)
    {
        Instantiate(bulletPrefab, spawnPosition.position, transform.rotation);
        yield return new WaitForSeconds(secondShotDelay);
        Instantiate(bulletPrefab, spawnPosition.position, transform.rotation);
    }
}
