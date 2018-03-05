using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Abstract class is hidden from the component search so it cant be used on an object directly.
public abstract class AbstractBehavior : MonoBehaviour {

    public Buttons[] inputButtons;
    public MonoBehaviour[] disableScripts;

    // Protected - private except for classes that extend it.
    protected InputState inputState;
    protected Rigidbody2D rb2d;
    protected CollisionState collisionState;

    // Virtual - To be overridden by classes that extend this one.
    protected virtual void Awake() {
        inputState = GetComponent<InputState>();
        rb2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    protected virtual void ToggleScripts(bool value) {
        foreach (MonoBehaviour script in disableScripts) {
            script.enabled = value;
        }
    }
}
