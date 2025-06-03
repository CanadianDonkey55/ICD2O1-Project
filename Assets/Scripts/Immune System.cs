using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImmuneSystem : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    [Header("Damage")]
    public float health = 10f;
    public float increasedHealth = 15f;
    public bool doubleShot = false;
    public float secondShotDelay = 0.3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction from object to mouse
        Vector3 direction = mousePos - transform.position;

        // Calculate angle in degrees and rotate the object
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // Check for mouse click and clone the bullet prefab
        if (Input.GetMouseButtonDown(0))
        {
            if (doubleShot)
            {
                StartCoroutine(DoubleShotCoroutine());
            }
            else
            {
                Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            }
        }

        // Check for death
        if (health <= 0) SceneManager.LoadScene(2);
    }

    // Coroutine for double shot
    private IEnumerator DoubleShotCoroutine()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        yield return new WaitForSeconds(secondShotDelay);
        Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
    }
}
