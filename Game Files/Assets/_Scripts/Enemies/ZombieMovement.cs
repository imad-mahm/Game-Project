using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2f; 
    private SpriteRenderer spriteRenderer; 
    [SerializeField] private Animator animator;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!animator.GetBool("isDead"))
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
            animator.SetBool("isWalking", true);
        }

        //if (spriteRenderer)
       // {
       //     spriteRenderer.flipX = true; 
       // }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Zombie Triggered");
        if (collision.CompareTag("ZombieKillzone"))
        {
            Debug.Log("Zombie dead");
            animator.SetBool("isDead", true);
            speed = 0f;
            Debug.Log("Zombie Dead");
        }
    }

    
    public void DestroyAfterDeath()
    {
        Destroy(gameObject);
    }

}


