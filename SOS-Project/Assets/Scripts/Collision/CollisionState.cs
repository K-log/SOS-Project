using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour {

    public LayerMask collisionLayer;
    public bool standing;
    public bool onWall;
    public Vector2 bottomPosition = Vector2.zero;
    public Vector2 rightPosition = Vector2.zero;
    public Vector2 leftPosition = Vector2.zero;
    public float collisionRadius = 0.5f;
    public Color debugCollisionColor = Color.red;

    private InputState inputState;

	// Use this for initialization
	void Start () {
        inputState = GetComponent<InputState>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        Vector2 pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);

        pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        onWall = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);

        if (onWall && standing) { // Make standing on the ground override touching a wall
            onWall = false;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = debugCollisionColor;

        Vector2[] positions = new Vector2[] { rightPosition, bottomPosition, leftPosition };

        foreach (Vector2 position in positions) {
            Vector2 pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            Gizmos.DrawWireSphere(pos, collisionRadius);
        }
    }
}
