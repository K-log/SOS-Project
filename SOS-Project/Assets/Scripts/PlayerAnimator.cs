using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private Animator anim;
    
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Move the player up
        {
            anim.SetBool("WalkUp", true);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
        }

        if (Input.GetKey(KeyCode.A)) // Move the player left
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", true);
            anim.SetBool("WalkRight", false);
        }

        if (Input.GetKey(KeyCode.S)) // Move the player down
        {
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", true);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", false);
        }

        if (Input.GetKey(KeyCode.D)) // Move the player right
        {
            anim.SetBool("WalkUp", true);
            anim.SetBool("WalkDown", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", true);
        }



    }
}
