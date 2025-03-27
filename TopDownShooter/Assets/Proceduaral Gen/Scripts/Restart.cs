using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnProtection;
    public Transform spawnTarget;
    public float destroyRadius = 15f; // Radius within which enemies will be destroyed
    public string enemyTag = "Enemy"; // Tag to identify enemy objects

    public void RestartLevel()
    {
        player.transform.position = spawnTarget.position;
        // Find all enemies with the specified tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            // Calculate the distance from the center point
            float distance = Vector3.Distance(spawnTarget.position, enemy.transform.position);

            // If the enemy is within the specified radius, destroy it
            if (distance <= destroyRadius)
            {
                Destroy(enemy);
            }
        }
    }
}
