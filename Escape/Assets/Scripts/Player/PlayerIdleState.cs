using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        player.SetAnimation("idle");
    }

    public override void OnCollisionEnter2D(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {

        if (Input.GetButtonDown("Horizontal"))
        {
            player.TransitionToState(player.RunState);
        }

        player.CheckForJump();
    }
}
