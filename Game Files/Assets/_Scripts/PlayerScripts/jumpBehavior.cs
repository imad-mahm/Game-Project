using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBehavior : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public playerMovement playerMovement;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    

    private void Awake()
    {
        playerMovement = GetComponent<playerMovement>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.isGrounded)
        {
            Jump();
            
        }
        
    }

    void Jump()
    {
        playerRigidBody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        ThemeManager.Instance.ToggleTheme();
    }
}
