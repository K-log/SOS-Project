using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : AbstractBehavior {

    public float scale = 0.4f;
    public bool crouching;
    public float centerOffsetY = 0f;

    private CircleCollider2D circleCollider;
    private Vector2 originalCenter;

    protected override void Awake() {
        base.Awake();

        circleCollider = GetComponent<CircleCollider2D>();
        originalCenter = circleCollider.offset;
    }

    // Shrink the player's circle collider so that it matches the player's new smaller size.
    // This still needs some tuning as the circle collider is still too big.
    protected virtual void OnCrouch(bool value) {
        crouching = value;

        ToggleScripts(!crouching);

        float size = circleCollider.radius;

        float newOffsetY;
        float sizeReciprocal;

        if (crouching) {
            sizeReciprocal = scale;
            newOffsetY = circleCollider.offset.y - size / 2 + centerOffsetY;
        }
        else {
            sizeReciprocal = 1 / scale;
            newOffsetY = originalCenter.y;
        }

        size = size * sizeReciprocal;
        circleCollider.radius = size;
        circleCollider.offset = new Vector2(circleCollider.offset.x, newOffsetY);
    }
	
	// Update is called once per frame
	void Update () {
        bool canCrouch = inputState.GetButtonValue(inputButtons[0]);
        if (canCrouch && collisionState.standing && !crouching) {
            OnCrouch(true);
        } else if (crouching && !canCrouch) {
            OnCrouch(false);
        }
	}
}
