using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // The enemy prefab
    public float spawnInterval = 2f; // Time between spawns
    public Transform[] spawnPoints; // Array of spawn points
    public Animator anim;

    private void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        anim.SetBool("isSpawning", true);
        if (spawnPoints.Length == 0) return; // No spawn points available

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the enemy prefab at the spawn point
        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
        //WaitForSeconds(0.5f);
        //anim.SetBool("isSpawning", false);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                //Gizmos.DrawSphere(spawnPoint.position, 0.5f);
            }
        }
    }

    public void StopSpawningAnimation()
    {
        anim.SetBool("isSpawning", false);
    }
}
