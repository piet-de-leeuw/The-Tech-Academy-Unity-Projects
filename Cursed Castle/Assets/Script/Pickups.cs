using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupAnaimation();
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
    }
    private void PickupAnaimation()
    {
        animator.SetTrigger("pickup");
    }
    void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
