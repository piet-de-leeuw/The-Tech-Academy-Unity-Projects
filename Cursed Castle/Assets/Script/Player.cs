using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    Rigidbody2D myRigidbody2D;
    Animator animator;
    Collider2D playerCollider;
    LayerMask ground;

    [SerializeField] float speed = 10f;
    [SerializeField] float jumpHight = 4;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
        ground = LayerMask.GetMask("Ground");
    }

    void Update()
    {

        Run();
        Jump();
    }

    private void Run()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        myRigidbody2D.velocity = new Vector2 (horizontal * speed * Time.deltaTime, myRigidbody2D.velocity.y);
        
        FlipSprite();
        RunAnimation();
    }

    private void FlipSprite()
    {
        bool isRunning = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (isRunning)
        {
            float direction = Mathf.Sign(myRigidbody2D.velocity.x);
            transform.localScale = new Vector2(direction, 1f);
        }
    }
    private void RunAnimation()
    {
        bool isRunning = MathF.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("running", isRunning);

    }

    private void Jump() 
    {
        if (!playerCollider.IsTouchingLayers(ground)) { return; }
        
        bool isJumping = CrossPlatformInputManager.GetButtonDown("Jump");
        if (isJumping)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHight);
        }
    }
}
