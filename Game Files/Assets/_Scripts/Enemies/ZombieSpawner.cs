using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // The enemy prefab
    public float spawnInterval = 2f; // Time between spawns
    public Transform spawnPoint; // Array of spawn points
    public Animator anim;

    private void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        anim.SetTrigger("isSpawning" );
    }

    private void SpawnThem()
    {
        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isDead", true);
        }
    }
}
