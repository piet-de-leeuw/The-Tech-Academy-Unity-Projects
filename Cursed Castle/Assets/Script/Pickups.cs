using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    Animator animator;

    [SerializeField] bool isHeart, isDiamond;
    GameSession gameSession;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameSession = FindObjectOfType<GameSession>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupAnaimation();
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);

        if (isDiamond) { gameSession.AddScore(5); }
        if (isHeart) { gameSession.AddLive(); }
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
