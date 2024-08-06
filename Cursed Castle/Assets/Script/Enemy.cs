using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    Animator animator;

    [SerializeField] float runSpeed = 20f;
    [SerializeField] AudioClip dieSFX;


    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        FlipSprite(other);
    }

    private void Movement()
    {
        if (IsFacingLeft())
        {
            myRigidbody2D.velocity = new Vector2(-runSpeed, myRigidbody2D.velocity.y); 
            return;
        }
        myRigidbody2D.velocity = new Vector2(runSpeed, myRigidbody2D.velocity.y);
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x > 0;
    }

    private void FlipSprite(Collider2D other)
    {
        if (other.isTrigger) { return; }
        float direction = Mathf.Sign(myRigidbody2D.velocity.x);
        transform.localScale = new Vector2(direction, 1f);

    }

    public void Die()
    {
        animator.SetTrigger("die");
        AudioSource.PlayClipAtPoint(dieSFX, Camera.main.transform.position);
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        myRigidbody2D.bodyType = RigidbodyType2D.Static;
        StartCoroutine(WaitForDistroy());
    }


    IEnumerator WaitForDistroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
