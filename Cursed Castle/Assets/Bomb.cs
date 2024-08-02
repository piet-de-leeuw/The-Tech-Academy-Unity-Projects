using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        animator.SetTrigger("activateBomb");
        
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
