using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject); // Destroy bullet on hit
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            Destroy(gameObject); // Destroy bullet on hit
        }
    }

    void Update()
    {
        // Destroy bullet after a certain time
        Destroy(gameObject, 2f);
    }

    
}
