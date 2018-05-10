using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Changes the direction the player is facing based on the player's input. 
 * Remember to changes the inputs array in the inspector when using on an object.
 */


public class FaceDirection : AbstractBehavior {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);

        if (right){
            inputState.direction = Directions.Right;
        }
        else if (left) {
            inputState.direction = Directions.Left;
        }

        Debug.Log("Change Direction");
        transform.localScale = new Vector3((float)inputState.direction, 1, 0); // If the Object stops appearing in the scene, change the Z value.
        Debug.Log(transform.localScale);
	}
}
