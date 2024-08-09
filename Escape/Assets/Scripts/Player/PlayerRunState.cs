using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("run");
    }

    public override void OnCollisionEnter2D(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {
        float horizontal = Input.GetAxis("Horizontal");
        player.Rigidbody2D.velocity = new Vector2(horizontal * player.runSpeed, player.Rigidbody2D.velocity.y);

        if (horizontal < Mathf.Epsilon && horizontal > 0)
        {
            player.TransitionToState(player.IdleState);
        }

        player.CheckForJump();


    }
}
