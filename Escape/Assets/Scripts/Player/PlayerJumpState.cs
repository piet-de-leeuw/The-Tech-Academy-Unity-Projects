using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    bool isGoiningUp;


    public override void EnterState(PlayerController player)
    {
        player.Rigidbody2D.velocity = new Vector2 (player.Rigidbody2D.velocity.x, player.jumpSpeed);
        player.SetAnimation("jump");
    }

    public override void OnCollisionEnter2D(PlayerController player)
    {
        //Ignores the collision when going through a platform from under it. 
        if (isGoiningUp) { return; }
       
        player.TransitionToState(player.IdleState);
    }

    public override void Update(PlayerController player)
    {
        isGoiningUp = player.Rigidbody2D.velocity.y > 0;

        player.MoveLeftRight(player.jumpSpeed);
        //float horizontal = Input.GetAxis("Horizontal");
        //player.Rigidbody2D.velocity = new Vector2(horizontal * player.runSpeed, player.Rigidbody2D.velocity.y);
    }
}
