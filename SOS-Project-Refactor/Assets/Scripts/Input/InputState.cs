using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Holds the state of all of our buttons in a Dictionary for easy access.
 * Dictionary: Key = Button, Value = ButtonState.
 * 
 * If a button does not exist in the Dictionary yet, then add it.
 */


/* Holds the state of the current button.
 * value: True = pressed, False = not pressed.
 * holdTime: The length of time a button has been pressed.
 */
public class ButtonState{
    public bool value;  
    public float holdTime = 0;
}

// Holds the directions the player can face.
public enum Directions {
    Right = 1,
    Left = -1
}


public class InputState : MonoBehaviour {

    public Directions direction = Directions.Right; // Assume every object starts out facing right. Keep the artwork consistent!
    public float absVelX = 0f;
    public float absVelY = 0f;

    private Rigidbody2D rb2d;
    private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();
    
    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        absVelX = Mathf.Abs(rb2d.velocity.x);
        absVelY = Mathf.Abs(rb2d.velocity.y);
    }


    //Set the current button state value to the given value
    // If a button does not already exist then create it.
    public void SetButtonValue(Buttons key, bool value) {
        if (!buttonStates.ContainsKey(key)) {
            buttonStates.Add(key, new ButtonState());
        }
       
        // Get the previous state of the button.
        var state = buttonStates[key];

        // If the value is true then the button is being pressed.
        // If the value is false then the button is not being pressed.
        if (state.value && !value){
            Debug.Log("Button" + key + "released");
            state.holdTime = 0;
        }
        else if (state.value && value) {
            state.holdTime += Time.deltaTime;
            // Debug.Log("Button" + key + "down" + state.holdTime);
        }

        // Change the previous state of the button to the current state.
        state.value = value;
    }

    public bool GetButtonValue(Buttons key) {
        if (buttonStates.ContainsKey(key)) {
            return buttonStates[key].value;
        }
        else {
            return false; 
        }
    }

    public float GetButtonHoldTime(Buttons key) {
        if (buttonStates.ContainsKey(key))
        {
            return buttonStates[key].holdTime;
        }
        else
        {
            return 0;
        }
    }
}
