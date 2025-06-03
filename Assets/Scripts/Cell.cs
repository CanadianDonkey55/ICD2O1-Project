using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    Rigidbody2D rb;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Cause the cell to move in a straight line
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // Makes sure there aren't too may cells in the scene to reduce lag
        Destroy(gameObject, 5);
    }
}