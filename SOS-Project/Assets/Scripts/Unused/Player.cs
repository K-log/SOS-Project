using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool doubleJump = false;
    [HideInInspector] public bool wallJump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 500f;
    public float maxJumpForce = 60f;
    public Transform groundCheck;
    public Transform wallCheck;
    public Transform attackCheck;

    private bool grounded = false;
    private bool walled = false;
    private bool readyForDoubleJump = false;
    private bool damage = false;
    private float currInput;
    private float previousLocation = 0;
    private Animator anim;
    private Rigidbody2D rb2d;
    

    void Awake() {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    

	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        walled = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Wall"));

        //damage = Physics2D.IsTouchingLayers("Enemies");

        anim.SetBool("Ground", grounded);

        if (grounded)
        {
            anim.SetBool("Idle",(Mathf.Abs(rb2d.velocity.x) < 0.4));
        }

        if (Input.GetButtonDown("Attack"))
        {
            anim.SetBool("Attack", true);
            if (damage) {
                Debug.Log("Damaged");

            }
        }
        else {
            anim.SetBool("Attack", false);
        }
        

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            readyForDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump") && !grounded && walled)
        {
            wallJump = true;
            readyForDoubleJump = false;
            currInput = h;
        }

        if (Input.GetButtonDown("Jump") && !grounded && !jump && readyForDoubleJump)
        {
            doubleJump = true;
            readyForDoubleJump = false;
        }       

        Debug.Log("Grouned: " + grounded);
        Debug.Log("Walled: " + walled);

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump && !doubleJump)
        {
            anim.SetTrigger("Jump");
            if (Mathf.Abs(rb2d.velocity.y) > maxJumpForce)
                rb2d.velocity = new Vector2(rb2d.velocity.x, maxJumpForce);
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

        if (walled && !grounded) {
            if (Mathf.Abs(rb2d.velocity.y) > maxJumpForce)
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            if (previousLocation > rb2d.transform.position.y)
            {
                rb2d.AddForce(new Vector2(0f, rb2d.velocity.y * -4));
            }

            previousLocation = rb2d.transform.position.y;
        }

        Debug.Log(Mathf.Abs(h - currInput));
        if (wallJump && Mathf.Abs(h - currInput) > 0.7)
        {
            if (Mathf.Abs(rb2d.velocity.y) > maxJumpForce)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            } else {
                rb2d.AddForce(new Vector2(rb2d.velocity.x, maxJumpForce - rb2d.velocity.y));
            }

            anim.SetTrigger("Jump");
            wallJump = false;
            doubleJump = false;
            jump = true;
        }

        if (doubleJump && !readyForDoubleJump) {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            doubleJump = false;
            jump = true;

        }       
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

