using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The buttons used in the game
public enum Buttons {
    Right,
    Left,
    Run,
    Jump,
    Crouch
}

// Conditions for input states
public enum Condition {
    GreaterThan,
    LessThan
}


// Get the axis state from the unity input manager 
[System.Serializable]
public class InputAxisState {
    public string axisName;
    public float offValue;
    public Buttons button;
    public Condition condition;

    public bool value {
        get {
            float val = Input.GetAxis(axisName);

            switch (condition) {
                case Condition.GreaterThan:
                    return val > offValue;
                case Condition.LessThan:
                    return val < offValue;
            }
            return false;
        }
    }

}



public class InputManager : MonoBehaviour {

    public InputAxisState[] inputs;
    public InputState inputState;

    void Start()
    {
        
    }

    void Update() {
        foreach (var input in inputs) {
            inputState.SetButtonValue(input.button, input.value);
        }
    }
}
