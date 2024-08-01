using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    Rigidbody2D myRigidbody2D;
    Animator animator;
    BoxCollider2D bodyCollider;
    PolygonCollider2D feetCollider;
    LayerMask ground;
    LayerMask climb;

    [SerializeField] float runSpeed = 1900f;
    [SerializeField] float jumpHeight = 16f;
    [SerializeField] float climbSpeed = 800f;

    float initialGravityScale;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<BoxCollider2D>();
        feetCollider = GetComponent<PolygonCollider2D>();

        initialGravityScale = myRigidbody2D.gravityScale;

        ground = LayerMask.GetMask("Ground");
        climb = LayerMask.GetMask("Hanging Sheets");
    }

    void Update()
    {

        Run();
        Jump();
        Climb();
    }

    private void Run()
    {
        float runDirection = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
        myRigidbody2D.velocity = new Vector2(runDirection , myRigidbody2D.velocity.y);
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
        if (!feetCollider.IsTouchingLayers(ground) && !feetCollider.IsTouchingLayers(climb)) { return; }

        bool isJumping = CrossPlatformInputManager.GetButtonDown("Jump");
        if (isJumping)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
        }
    }

    private void Climb()
    {
        if (bodyCollider.IsTouchingLayers(climb))
        {
            myRigidbody2D.gravityScale = 0f;
            float climbeDirection = CrossPlatformInputManager.GetAxis("Vertical") * climbSpeed * Time.deltaTime;
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbeDirection);

        }
        else
        {
            myRigidbody2D.gravityScale = initialGravityScale;
        }

        bool isClimbing = Math.Abs(myRigidbody2D.velocity.y) > Mathf.Epsilon;
        animator.SetBool("climbing", isClimbing);

    }
}
