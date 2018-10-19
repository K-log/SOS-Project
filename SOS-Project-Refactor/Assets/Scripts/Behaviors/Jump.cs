using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehavior {
    public float jumpSpeed = 20f;
    public float jumpDelay = 0.1f;
    public int jumpCount = 2;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;

    // Can be overidden by child classes
    protected virtual void Update()
    {
        bool canJump = inputState.GetButtonValue(inputButtons[0]);
        float holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (collisionState.standing)
        {
            if (canJump && holdTime < 0.1f)
            {
                jumpsRemaining = jumpCount - 1;
                OnJump();
            }
        }
        else
        {
            if (canJump && holdTime < 0.1f && Time.time - lastJumpTime > jumpDelay)
            {
                if (jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining--;
                }
            }
        }
    }

    protected virtual void OnJump() {
        Vector2 vel = rb2d.velocity;
        lastJumpTime = Time.time;
        rb2d.velocity = new Vector2(vel.x, jumpSpeed);

    }

}
