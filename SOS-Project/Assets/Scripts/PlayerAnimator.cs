using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private Animator anim;

    public int facingDir = 0;  // The direction the player is facing. 0 = UP, 1 = DOWN, 2 = LEFT, 3 = RIGHT


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Started");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(facingDir);
        if (Input.GetKey(KeyCode.W)) // Move the player up
        {
            facingDir = 0;
            anim.SetBool("WalkUp", true);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", false);
        }
        else if (Input.GetKey(KeyCode.S)) // Move the player down
        {
            facingDir = 1;
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", true);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", false);
        }
        else if (Input.GetKey(KeyCode.A)) // Move the player left
        {
            facingDir = 2;
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", true);
            anim.SetBool("WalkRight", false);
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", false);
        }
        else if (Input.GetKey(KeyCode.D)) // Move the player right
        {
            facingDir = 3;
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", true);
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", false);
        }
        else {
            anim.SetBool("Idle", true);
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
            anim.SetBool("AttackUp", false);
            anim.SetBool("AttackDown", false);
            anim.SetBool("AttackLeft", false);
            anim.SetBool("AttackRight", false);
        }



        // Player attack animations
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ( facingDir == 0) // Attack UP
            {
                anim.SetBool("AttackUp", true);
                anim.SetBool("AttackDown", false);
                anim.SetBool("AttackLeft", false);
                anim.SetBool("AttackRight", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", false);
            }
            else if (facingDir == 1) // Attack DOWN
            {
                anim.SetBool("AttackUp", false);
                anim.SetBool("AttackDown", true);
                anim.SetBool("AttackLeft", false);
                anim.SetBool("AttackRight", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", false);
            }
            else if (facingDir == 2) // Attack LEFT
            {
                anim.SetBool("AttackUp", false);
                anim.SetBool("AttackDown", false);
                anim.SetBool("AttackLeft", true);
                anim.SetBool("AttackRight", false);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", false);
            }
            else if (facingDir == 3) // Attack right
            {
                Debug.Log("Attack Right");
                anim.SetBool("AttackUp", false);
                anim.SetBool("AttackDown", false);
                anim.SetBool("AttackLeft", false);
                anim.SetBool("AttackRight", true);
                anim.SetBool("WalkUp", false);
                anim.SetBool("WalkDown", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", false);
            }
        }
    }
}
