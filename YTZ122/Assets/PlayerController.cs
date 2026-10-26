using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;   // how fast the character moves
    public float jumpHeight;  // how high the character jumps

    public KeyCode Spacebar;  // jump button
    public KeyCode L;         // left movement button
    public KeyCode R;         // right movement button

    public Transform groundCheck;      // invisible point at the player's feet
    public float groundCheckRadius;    // size of the circle around the feet
    public LayerMask whatIsGround;     // what is considered ground
    private bool grounded;             // is the character standing on solid ground

    private Animator anim; // controls the character's animation in code

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("Grounded", grounded);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}