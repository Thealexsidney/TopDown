using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy
    public float shootingRange = 5f; // Range to shoot the player
    public float followRange = 5f;
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform firePoint; // Point from where the bullet will be fired
    private Transform player;
    private float timer = 0f;
    [SerializeField] private float firingRate = 1f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Find the player by tag
    }

    void Update()
    {
        timer += Time.deltaTime;
        // Move towards the player
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= shootingRange)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Shoot at the player
            if (timer >= firingRate)
            {
                Shoot();
                timer = 0;
            }
        }
        if (distance < followRange && distance > shootingRange)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = (player.position - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f; // Set bullet speed
    }
    
}
