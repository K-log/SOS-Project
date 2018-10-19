using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehavior {

    public float walkSpeed = 5f;
    public float runMultiplier = 2f;
    public bool running;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        running = false;

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);

        Debug.Log("right: " + right);
        Debug.Log("left: " + left);

        if (right || left) {
            float tempSpeed = walkSpeed;

            if (run && runMultiplier > 0) {
                tempSpeed *= runMultiplier;
                run = true;
            }

            float velX = tempSpeed * (float)inputState.direction;

            rb2d.velocity = new Vector2(velX, rb2d.velocity.y);

        }
    }
}
