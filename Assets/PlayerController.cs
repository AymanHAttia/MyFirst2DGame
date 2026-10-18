using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;

    public KeyCode L;
    public KeyCode R;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded;

    void Start()
    {

    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        // Move Left
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().linearVelocity =
                new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().linearVelocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // Move Right
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().linearVelocity =
                new Vector2(moveSpeed, GetComponent<Rigidbody2D>().linearVelocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }


    void FixUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().linearVelocity =
            new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, jumpHeight);
    }
}