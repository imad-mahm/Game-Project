using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2f; 
    private SpriteRenderer spriteRenderer; 
    [SerializeField] private Animator animator;
    private bool dead = false;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
        animator.SetBool("isWalking", true);
        //if (spriteRenderer)
        // {
        //     spriteRenderer.flipX = true; 
        // }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ZombieKillzone") && !dead)
        {
            Debug.Log("Zombie Triggered");
            Debug.Log("Zombie dead");
            animator.SetBool("isDead", true);
            speed = 0f;
            Debug.Log("Zombie Dead");
            dead = true;
        }
    }

    
    public void DestroyAfterDeath()
    {
        Destroy(gameObject);
    }

}


