using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Move player up
        {
            transform.Translate(Vector2.up * moveSpeed);
        }

        if (Input.GetKey(KeyCode.A)) // Move player left
        {
            transform.Translate(Vector2.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S)) // Move player down
        {
            transform.Translate(Vector2.down * moveSpeed);
        }

        if (Input.GetKey(KeyCode.D)) // Move player right
        {
            transform.Translate(Vector2.right * moveSpeed);
        }
    }

}
