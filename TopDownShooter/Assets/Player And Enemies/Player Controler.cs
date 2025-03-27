using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControler : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab; // Prefab for the projectile
    public float projectileSpeed = 10f;
    public Transform playerTransform; // Assign in the inspector
    public float radius = 15.0f; // Define radius

    private void Start()
    {
       
    }

    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        
        transform.Translate(movement * speed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0)) 
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Calculate direction to the cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }
}
