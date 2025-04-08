using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemies : MonoBehaviour
{
    List<Vector3Int> walkableTiles = new List<Vector3Int>();
    public Tilemap tilemap; // Reference to your Tilemap
    public int spawnCount;
    void IdentifyWalkableTiles()
    {
        walkableTiles.Clear();
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.x; x < bounds.xMax; x++)
        {
            for (int y = bounds.y; y < bounds.yMax; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(position);
                if (tile != null) // Check if the tile is not null (i.e., it's a valid tile)
                {
                    walkableTiles.Add(position);
                }
            }
        }
    }


    public GameObject enemyPrefab; // Reference to your enemy prefab

    void SpawnEnemy(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            if (walkableTiles.Count > 0)
            {
                int randomIndex = Random.Range(0, walkableTiles.Count);
                Vector3Int spawnPosition = walkableTiles[randomIndex];
                Vector3 worldPosition = tilemap.GetCellCenterWorld(spawnPosition);
                Instantiate(enemyPrefab, worldPosition, Quaternion.identity);
            }
        }
    }

    public void DestroyAllEnemies()
    {
        // Find all game objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Loop through the enemies and destroy them
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
            
        }
        

    }

    public bool AllEnemiesDead()
    {
        int enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesAlive == 0) { return true; };
        return false;
    }

    public void Spawn()
    {
        IdentifyWalkableTiles();
        SpawnEnemy(spawnCount);
         // Spawn 5 enemies
    }

   
}
