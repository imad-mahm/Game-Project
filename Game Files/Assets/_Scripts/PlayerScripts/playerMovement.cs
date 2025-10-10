using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    
    
    
    [Header("Movement")]
    public float moveHorizontal;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    private float _currentSpeed;
    private bool _isSprinting;
    
    
    [Header("GroundCheck")]
    private bool _isGrounded;
    public bool isGrounded => _isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;

    
    
    
    
    

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        _isGrounded =  Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        
    }

    private void FixedUpdate()
    {
        _currentSpeed = _isSprinting ?  sprintSpeed : walkSpeed;
        playerRigidBody.velocity = new Vector2(moveHorizontal* _currentSpeed,playerRigidBody.velocity.y);
    }
}
