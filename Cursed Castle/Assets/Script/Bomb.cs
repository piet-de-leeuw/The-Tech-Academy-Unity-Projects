using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator animator;
    LayerMask player;

    [SerializeField] float radius = 10;
    [SerializeField] Vector2 explotionForce = new Vector2(200f, 100f);


    void Start()
    {
        animator = GetComponent<Animator>();
        player = LayerMask.GetMask("Player");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        animator.SetTrigger("activateBomb");
    }

    void ExplodeBomb()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, radius, player);

        if(playerCollider)
        {
            // playerCollider.GetComponent<Rigidbody2D>().AddForce(explotionForce);
            playerCollider.GetComponent<Player>().PlayerHit();
        }
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
