using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            
            Destroy(gameObject); // Destroy bullet on hit
        }
        if (hitInfo.CompareTag("Wall"))
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
