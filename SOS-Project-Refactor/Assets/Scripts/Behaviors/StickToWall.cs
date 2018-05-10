using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToWall : AbstractBehavior {

    public bool onWallDetected;

    protected float defaultGravityScale;
    protected float defaultDrag;

	// Use this for initialization
	void Start () {
        defaultGravityScale = rb2d.gravityScale;
        defaultDrag = rb2d.drag;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (collisionState.onWall && !collisionState.standing) {
            if (!onWallDetected) {
                OnStick();
                ToggleScripts(false);
                onWallDetected = true;
                Debug.Log("Stuck to wall: " + onWallDetected);
            }
        }
        else {
            if (onWallDetected) {
                OffWall();
                ToggleScripts(true);
                onWallDetected = false;      
            }

        }
	}

    protected virtual void OnStick() {
        if (!collisionState.standing && rb2d.velocity.y > 0) { // Make the player stick to the wall 
            rb2d.gravityScale = 0;
            rb2d.drag = 100;
        }
    }

    protected virtual void OffWall() {
        if (rb2d.gravityScale != defaultGravityScale) { // Reset the player's grabity and drag when not touching the wall
            rb2d.gravityScale = defaultGravityScale;
            rb2d.drag = defaultDrag;
        }
    }
}
