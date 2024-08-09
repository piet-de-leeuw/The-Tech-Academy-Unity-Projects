using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    public Rigidbody2D Rigidbody2D { get { return rbody; } }
    Animator animator;

    public float runSpeed;
    public float jumpSpeed;

    PlayerBaseState currendState;
    public PlayerBaseState CurrendState { get { return currendState; } }

    public readonly PlayerBaseState IdleState = new PlayerIdleState();
    public readonly PlayerBaseState RunState = new PlayerRunState();
    public readonly PlayerBaseState DieState = new PlayerDieState();
    public readonly PlayerBaseState JumpState = new PlayerJumpState();

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        TransitionToState(IdleState);
    }


    void Update()
    {
        currendState.Update(this);
    }

    private void OnCollisionEnter2D()
    {
        Debug.Log("Collision");
        currendState.OnCollisionEnter2D(this);
    }

    public void TransitionToState(PlayerBaseState state)
    {
        currendState = state;
        currendState.EnterState(this);
    }

    public void CheckForJump()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TransitionToState(JumpState);
        }
    }

    public void SetAnimation(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    public void SetAnimation(string trigger, bool state)
    {
        animator.SetBool(trigger, state);
    }

    public void MoveLeftRight(float speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        rbody.velocity = new Vector2(horizontal * speed, rbody.velocity.y);
    }
}
