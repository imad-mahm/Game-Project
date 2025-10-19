using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
    public bool isGrounded;
    // public bool isGrounded => _isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
    
    public Animator anim;
    
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = 0.8f;
            transform.localScale = scale;
        }
        else if (moveHorizontal < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -0.8f;
            transform.localScale = scale;
        }
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        _currentSpeed = _isSprinting ?  sprintSpeed : walkSpeed;
        isGrounded =  Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (moveHorizontal != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        anim.SetBool("isSprinting", _isSprinting);
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(moveHorizontal* _currentSpeed ,playerRigidBody.velocity.y);
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Killzone"))
        {
            SceneManager.LoadScene(1);
            if (!BackgroundMusicManager.Instance.isLightMode)
            {
                BackgroundMusicManager.Instance.SwitchMusic();
            }
        } else if (other.CompareTag("Zombie"))
        {
            SceneManager.LoadScene(2);
        }
        else if (other.gameObject.CompareTag("witch"))
        {
            BackgroundMusicManager.Instance.PauseMusic();
            GameUICanvas.Instance.creditPanel.SetActive(true);
            GameUICanvas.Instance.dialoguePanel.SetActive(false);
            GameUICanvas.Instance.gameUIPanel.SetActive(false);
            GameUICanvas.Instance.mainMenuPanel.SetActive(false);
            GameUICanvas.Instance.optionsPanel.SetActive(false);
            GameUICanvas.Instance.pausePanel.SetActive(false);
           
        }
    }
}
