using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneSystem : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    [Header("Damage")]
    public float health = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction from object to mouse
        Vector3 direction = mousePos - transform.position;

        // Calculate angle in degrees and rotate the object
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // Check for mouse click and clone the bullet prefab
        if (Input.GetMouseButtonDown(0))
        {
            Console.WriteLine("pew pew");
            Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        }
    }
}