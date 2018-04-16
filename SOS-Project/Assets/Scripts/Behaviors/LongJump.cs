using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * If the jump button is held down as opposed to just pressed the player
 * will do a long jump with a higher velocity than a normal jump.
 */

public class LongJump : Jump {

    public float longJumpDelay = 0.15f;
    public float longJumpMultiplier = 1.5f;
    public bool canLongJump;
    public bool isLongJumping;

    protected override void Update() {

        bool canJump = inputState.GetButtonValue(inputButtons[0]);
        float holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (!canJump) {
            canLongJump = false;
        }

        if (collisionState.standing && isLongJumping) {
            isLongJumping = false;
        }

        base.Update(); // Call the parent class update code. Normal jump and double jump

        if (canLongJump && collisionState.standing && holdTime > longJumpDelay) {
            Vector2 vel = rb2d.velocity;
            rb2d.velocity = new Vector2(vel.x, jumpSpeed * longJumpMultiplier);
            canLongJump = false;
            isLongJumping = true;
        }
    }

    protected override void OnJump() {
        base.OnJump();
        canLongJump = true;
    }
}
