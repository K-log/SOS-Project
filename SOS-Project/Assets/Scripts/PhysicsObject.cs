using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = 0.65f;
    public float minWallNormalX = 0.85f;
    public float gravityModifier = 1f;

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected bool walled;
    protected bool canDoubleJump;
    protected Vector2 wallNormalTest;
    protected Vector2 groundNormal;
    protected Vector2 wallNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
	}

    void Update ()
    {
        targetVelocity = Vector2.zero;

        ComputeVelocity();
	}

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;
        walled = false;
        canDoubleJump = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        // ----- Horizontal Movement -----
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;
        Movement(move, false);

        // ----- Vertical Movement -----
        move = Vector2.up * deltaPosition.y;
        Movement(move, true);
    }


    // Controls all the physics checks for the players movement.
    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                Debug.DrawLine(hitBufferList[i].point, transform.Find("GroundDebug").position, color: Color.red, duration: 1, depthTest: false);

                Debug.Log("------------Player Collision Ground------------");
                Debug.Log("Ground Hit: " + hitBufferList[i].point);
                Debug.Log("Player Pos: " + transform.Find("GroundDebug").position);
                Debug.Log("Current Normal" + currentNormal.y + " " + currentNormal.x);
                Debug.Log("--------------------------------------");

                Debug.Log(Vector2.Dot(hitBufferList[i].point, wallNormalTest));

                if (Vector2.Dot(hitBufferList[i].point, wallNormalTest) < 0)
                {
                    canDoubleJump = true;
                }


                if (currentNormal.y > minGroundNormalY) // Jumping off of a horizontal(ground) plane.
                {
                        grounded = true;
                        canDoubleJump = true;
                        if (yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                }
                else if (currentNormal.x > minWallNormalX && !grounded && canDoubleJump) // Jumping off of a vertical(wall) plane.
                {
                        walled = true;
                        if (yMovement)
                        {
                            wallNormalTest = hitBufferList[i].point;
                            wallNormal = currentNormal;
                            currentNormal.y = 0;
                        }
                }

                float projection = Vector2.Dot(velocity, currentNormal);

                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;

                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
            
        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
