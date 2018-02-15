using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private Animator anim;

    public float moveSpeed = 3;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Started");
    }

    /* Key for the player movement animations.
     * The whole number signifies the direction.
     * The dicimal digits signifie the specific animation in that direction.
     * Directiom:
     * 1: Up
     *  10: IdleUp
     *  11: WalkUp
     *  12: AttackUp
     * 
     * 2: Down
     *  20: IdleDown
     *  21: WalkDown
     *  22: AttackDown
     *  
     * 3: Left
     *  30: IdleLeft
     *  31: WalkLeft
     *  32: AttackLeft
     * 4: Right
     *  40: IdleRight
     *  41: WalkRight
     *  42: AttackRight
     */


    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter() {
        if (Input.GetKey(KeyCode.W)) // Move the player up
        {
            Debug.Log("WalkUp");
            anim.SetInteger("Movement", 11);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) // Move the player down
        {
            Debug.Log("WalkDown");
            anim.SetInteger("Movement", 21);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A)) // Move the player left
        {
            Debug.Log("WalkLeft");
            anim.SetInteger("Movement", 31);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) // Move the player right
        {
            Debug.Log("WalkRight");
            anim.SetInteger("Movement", 41);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetInteger("Movement", 20); // Default to IdleDown
        }



        // Player attack animations
        if (Input.GetKey(KeyCode.Space))
        {
            if (anim.GetInteger("Movement") == 11) // Attack UP
            {
                anim.SetInteger("Movement", 12);
            }
            else if (anim.GetInteger("Movement") == 21) // Attack DOWN
            {
                anim.SetInteger("Movement", 22);
            }
            else if (anim.GetInteger("Movement") == 31) // Attack LEFT
            {
                anim.SetInteger("Movement", 32);
            }
            else if (anim.GetInteger("Movement") == 41) // Attack right
            {
                anim.SetInteger("Movement", 42);
            }
        }

    }
}
