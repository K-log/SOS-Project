using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private InputState inputState;
    private Walk walkBehavior;
    private Animator anim;
    private CollisionState collisionState;
    private Crouch crouchBehavior;

	// Use this for initialization
	void Start () {
        inputState = GetComponent<InputState>();
        walkBehavior = GetComponent<Walk>();
        anim = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
        crouchBehavior = GetComponent<Crouch>();
    }
	
	// Update is called once per frame
	void Update () {
        if (collisionState.standing ) { // Walk Right
            ChangeAnimationState(0);
        }
        if (inputState.absVelX > 0 ) { // Walk left
            ChangeAnimationState(1);
        }

        if (inputState.absVelY > 0 ) { // Jump animation
            ChangeAnimationState(2);
        }

        anim.speed = walkBehavior.running ? walkBehavior.runMultiplier : 1; // Match the speed of the animation to the movement speed

        if (crouchBehavior.crouching) { // Crouch animation
            ChangeAnimationState(3);
        }

        if (!collisionState.standing && collisionState.onWall) { // Stick to wall animation
            // ChangeAnimationState(4); Animation state does not exist yet
            Debug.Log("Playing stick on wall animation");
        }
    }

    void ChangeAnimationState(int value) {
        anim.SetInteger("AnimState", value);
    }
}
