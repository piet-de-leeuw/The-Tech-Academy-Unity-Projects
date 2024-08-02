using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;

    [SerializeField] float runSpeed = 2000f;


    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

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
            myRigidbody2D.velocity = new Vector2(-runSpeed * Time.deltaTime, myRigidbody2D.velocity.y); 
            return;
        }
        myRigidbody2D.velocity = new Vector2(runSpeed * Time.deltaTime, myRigidbody2D.velocity.y);
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

}
