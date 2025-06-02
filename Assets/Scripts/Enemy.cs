using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 2f;
    public float speed = 2f;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);

        if (health == 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cell")
        {
            health -= collision.GetComponent<Cell>().damage;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "ImmuneSystem")
        {
            collision.GetComponent<ImmuneSystem>().health -= damage;
            Destroy(gameObject);
        }
    }
}
