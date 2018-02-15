using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Floats
    public float maxSpeed = 30f;
    public float moveSeed = 20f;
    public float jumpPower = 400f;

    // Bools
    private bool canDoubleJump = true;
    public bool facingRight = true;

    // Stats (too be used later)
    public int currHealth;
    public int maxHealth = 10;

    // References
    private Rigidbody2D rb2d;
    private Animator anim;

    // grounded?
    private bool grounded;
    private float groundedRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    // Touching a wall?
    private bool walled;
    private float walledRadius = 0.6f;
    public Transform wallCheck;
    public LayerMask whatIsWall;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        groundCheck = transform.Find("GroundCheck");
        wallCheck = transform.Find("WallCheck");


        currHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        grounded = false;
        Collider2D[] groundColliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < groundColliders.Length; i++)
        {
            if (groundColliders[i].gameObject != gameObject)
                grounded = true;
                Debug.Log("Touching the ground");
        }
        anim.SetBool("Ground", grounded);

        Collider2D[] wallColliders = Physics2D.OverlapCircleAll(wallCheck.position, walledRadius, whatIsWall);
        for (int i = 0; i < wallColliders.Length; i++)
        {
            if (wallColliders[i].gameObject != gameObject)
                walled = true;
                Debug.Log("Touching a wall", wallColliders[i].gameObject);
        }
        anim.SetBool("Wall", walled);


        float walkInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        Move(walkInput, jumpInput);



    }

    public void Move(float move, bool jump)
    {

        //anim.SetFloat("jumpSpeed", rb2d.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (grounded || walled) {
            canDoubleJump = true;
        }

        WallJump(move, jump);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

        // If the player should jump...
        if (grounded && jump && anim.GetBool("Ground") )
        {
            // Add a vertical force to the player.
            grounded = false;
            anim.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(0f, jumpPower));
        }
        if (!grounded && jump && anim.GetBool("ground") && canDoubleJump) {
            grounded = false;
            anim.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(0f, jumpPower));
            canDoubleJump = false;
        }
    }

    private void WallJump(float move, bool jump) {
        if (walled && jump && canDoubleJump)
        {
            int jumpDir;
            int previousDir = 0;
            if (facingRight)
            {
                jumpDir = 1;
            }
            else
            {
                jumpDir = -1;
            }

            anim.SetBool("Ground", false);
            if (previousDir != jumpDir)
            {
                rb2d.velocity = new Vector2(-jumpDir * 10, jumpPower * 0.1f);
                anim.SetFloat("Speed", Mathf.Abs(move));
                canDoubleJump = false;
                Debug.Log(jumpDir);
                previousDir = jumpDir;
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
   