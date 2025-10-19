using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // The enemy prefab
    public float spawnInterval = 2f; // Time between spawns
    public Transform[] spawnPoints; // Array of spawn points

    private void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return; // No spawn points available

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the enemy prefab at the spawn point
        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                Gizmos.DrawSphere(spawnPoint.position, 0.5f);
            }
        }
    }
}
