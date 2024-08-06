using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [SerializeField] float runSpeed = 22f;
    [SerializeField] float jumpHeight = 16f;
    [SerializeField] float climbSpeed = 11f;
    [SerializeField] float attackRadius = 3f;
    
    [SerializeField] float waitForMovement = 2f;
    bool canMove = true;
    [SerializeField] Vector2 hitForce = new Vector2(50f, 50f);
    
    [SerializeField] Transform attackBox;
    Rigidbody2D myRigidbody2D;
    Animator animator;
    BoxCollider2D bodyCollider;
    PolygonCollider2D feetCollider;
    AudioSource audioSource;
    LayerMask ground;
    LayerMask climb;
    LayerMask enemy;

    [SerializeField] AudioClip runSFX, jumpSFX, attackSFX, getHitSFX;


    float initialGravityScale;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<BoxCollider2D>();
        feetCollider = GetComponent<PolygonCollider2D>();
        audioSource = GetComponent<AudioSource>();

        initialGravityScale = myRigidbody2D.gravityScale;

        ground = LayerMask.GetMask("Ground");
        climb = LayerMask.GetMask("Hanging Sheets");
        enemy = LayerMask.GetMask("Enemy");

        animator.SetTrigger("enter");
    }

    void Update()
    {
        if(canMove)
        {
            Run();
            Jump();
            Climb();
            Attack();
            ExitLevel();

            if (myRigidbody2D.IsTouchingLayers(enemy))
            {
                PlayerHit();
            }
        }

    }


    private void Run()
    {
        if (!canMove){ return; }
        float runDirection = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;
        myRigidbody2D.velocity = new Vector2(runDirection , myRigidbody2D.velocity.y);
        FlipSprite();
        RunAnimation();
        bool isRunning = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        if (isRunning && !audioSource.isPlaying)
        {
            if (feetCollider.IsTouchingLayers(ground))
            {
                audioSource.PlayOneShot(runSFX);
            }
            else
            {
                audioSource.Stop();
            }
        }

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
            audioSource.PlayOneShot(jumpSFX);            
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);

        }
    }

    private void Climb()
    {
        float climbeDirection = 0f;
        if (bodyCollider.IsTouchingLayers(climb))
        {
            myRigidbody2D.gravityScale = 0f;
            climbeDirection = CrossPlatformInputManager.GetAxis("Vertical") * climbSpeed ;
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbeDirection);

        }
        else
        {
            myRigidbody2D.gravityScale = initialGravityScale;
        }

        bool isClimbing = Math.Abs(climbeDirection) > Mathf.Epsilon;
        animator.SetBool("climbing", isClimbing);
        if (isClimbing && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(runSFX);
        }

    }

    public void PlayerHit()
    {
        animator.SetTrigger("getHit");
        myRigidbody2D.velocity = hitForce * new Vector2(-transform.localScale.x, 1f);
        audioSource.PlayOneShot(getHitSFX);

        
        canMove = false;
        FindObjectOfType<GameSession>().ProcessPlayerLives();
        StartCoroutine(EnableMovement());
    }

    IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(waitForMovement);
        canMove = true;

    }

    void Attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(attackSFX);
            animator.SetTrigger("attack");

            Collider2D[] enemys = Physics2D.OverlapCircleAll(attackBox.position, attackRadius, enemy);

            foreach (Collider2D enemy in enemys)
            {
                enemy.GetComponent<Enemy>().Die();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackBox.position, attackRadius);
    }

    private void ExitLevel()
    {
        if (!myRigidbody2D.IsTouchingLayers(LayerMask.GetMask("Interactable"))) { return; }

        if (CrossPlatformInputManager.GetButton("Vertical"))
        {
            animator.SetTrigger("exit");
        }
    }

    public void NextLevel()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        FindObjectOfType<ExitDoor>().StartLoadingNextLevel();
    }
}
