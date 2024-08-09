using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    
    public override void EnterState(PlayerController player)
    {
        player.Rigidbody2D.velocity = new Vector2 (player.Rigidbody2D.velocity.x, player.jumpSpeed);
        player.SetAnimation("jump");
    }

    public override void OnCollisionEnter2D(PlayerController player)
    {
        Debug.Log("Idle");
        player.TransitionToState(player.IdleState);
    }

    public override void Update(PlayerController player)
    {
        float horizontal = Input.GetAxis("Horizontal");
        player.Rigidbody2D.velocity = new Vector2(horizontal * player.runSpeed, player.Rigidbody2D.velocity.y);
    }
}
