using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerControler : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab; // Prefab for the projectile
    public float projectileSpeed = 10f;
    public Transform playerTransform; // Assign in the inspector
    public float radius = 15.0f; // Define radius
    public GameObject pauseMenu;
    private bool isPaused = true;
    public int Health;
    public int maxHealth;
    public TextMeshProUGUI healthText;
    private void Start()
    {
        Time.timeScale = isPaused ? 0f : 1f;
        healthText.text = "Health: " + Health + "/" + maxHealth;
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
        int enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (!isPaused)
        {
            if (enemiesAlive == 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
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

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenu.SetActive(isPaused);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Health--;

            healthText.text = "Health: " + Health + "/" + maxHealth;

            if (Health <= 0)
            {
                SceneManager.LoadScene("SampleScene");
                Health = maxHealth;
            }




            Destroy(other.gameObject);

        }

        if (other.CompareTag("Heal"))
        {
            if (Health < maxHealth)
            {
                Health++;
                Destroy(other.gameObject);
                healthText.text = "Health: " + Health + "/" + maxHealth;
            }

        }
    }


}
