using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class jumpBehavior : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public playerMovement playerMovement;

    [Header("Jump")] [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float coyotetime;
    [SerializeField] private bool jumpbuffer;
    [SerializeField] private float buff;
    
    private float mayJump;
    private float jumpBufferTimer=0;

    [SerializeField] private GameObject[] lightPlatforms;
    [SerializeField] private GameObject[] darkPlatforms;


    private void Awake()
    {
        playerMovement = GetComponent<playerMovement>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        lightPlatforms = GameObject.FindGameObjectsWithTag("Light");
        darkPlatforms = GameObject.FindGameObjectsWithTag("Dark");
    }

    void Start()
    {
        foreach (var darkPlatform in darkPlatforms)
        {
            darkPlatform.SetActive(false);
        }
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
        
        if (playerMovement.isGrounded)
        {
            mayJump = coyotetime;
        }
        else
        {
            mayJump -= Time.deltaTime;
        }
        if (jumpbuffer && mayJump >= 0)
        {
            jumpbuffer=false;
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            SwitchPlatforms();
        }

        if (Input.GetKeyUp(KeyCode.Space) && playerRigidBody.velocity.y > 0)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0);
        }
        
        
        
    }





    private void SwitchPlatforms()
    {
        foreach (var darkPlatform in darkPlatforms)
        {
            darkPlatform.SetActive(!darkPlatform.activeInHierarchy);
        }

        foreach (var lightPlatform in lightPlatforms)
        {
            lightPlatform.SetActive(!lightPlatform.activeInHierarchy);
        }
    }
}