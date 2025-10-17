using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpBehavior : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public playerMovement playerMovement;

    [Header("Jump")] [SerializeField] private float jumpForce;
    [SerializeField] private float coyotetime;
    [SerializeField] private bool jumpbuffer;
    [SerializeField] private float buff;
    [SerializeField]private float JumpCooldown;
    
    private float mayJump;
    private float jumpBufferTimer;
    private float jumpCooldownTimer;
    private bool jumped;
    

    [SerializeField] private GameObject[] lightPlatforms;
    [SerializeField] private GameObject[] darkPlatforms;
    
    public Animator anim;


    private void Awake()
    {
        
        playerMovement = GetComponent<playerMovement>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        jumpCooldownTimer = 0;
        jumpBufferTimer = 0;
        
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpbuffer = true;
        }

        if (jumpbuffer)
        {
            jumpBufferTimer += Time.deltaTime;
        }

        if (jumpBufferTimer > buff)
        {
            jumpbuffer = false;
            jumpBufferTimer = 0;
        }

        if (jumped)
        {
            jumpCooldownTimer -= Time.deltaTime;
        }
        
        if (playerMovement.isGrounded)
        {
            mayJump = coyotetime;
        }
        else
        {
            mayJump -= Time.deltaTime;
        }
        if (jumpbuffer && mayJump > 0 && jumpCooldownTimer <= 0)
        {
            jumpbuffer=false;
            mayJump = 0;
            jumped = true;
            jumpCooldownTimer = JumpCooldown;
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            WorldFlipEvent.TriggerWorldFlip();

            // anim.SetTrigger("isJumping");
            if (SceneManager.GetActiveScene().name != "Level 2(escape Assylum)")
            {
                BackgroundMusicManager.Instance.SwitchMusic();
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) && playerRigidBody.velocity.y > 0)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0);
        }
        
        
        anim.SetBool("isGrounded", playerMovement.isGrounded);
    }
    
}