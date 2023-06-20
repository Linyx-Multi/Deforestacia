using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Variables for different parts of the script, the names should explain enough, yeeeessss....?

    private float horizontal;
    private bool isFacingRight = true;

    // Cereal-ized Fields.. got a transformed, rigid mask..
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpingPower = 7f;

    // OncePerFrame update check for if playercharacter needs flip, oh and jumping.. thats probably important.. i think?
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Returns either 1, 0 or -1

        if (Input.GetButtonDown("Jump") && IsGrounded()) // no double-jumping, hopefully..
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // jump in a direction, maybe?
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // Gets X velo, and Y velo and multiplies by 0.5, jump high by holding.
        }

        Flip(); // DO A FLIP!
    }

    // FixedUpdate checks for speed and horizontal movement and translates to velocity. *MATH*
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        /*s e c r e t  c o m m e n t*/
    }
    
    // are YOU grounded?
    private bool IsGrounded()
    {
        Debug.Log(Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer); // creates an overlap circle under the character to act as a ground check checksum.
    }

    // Do a barrel roll (Z or R twice) !
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) // Checks for right
         {
                isFacingRight = !isFacingRight; // is it facing right? now it is.
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
         }
    }

    public void devastationEffects()
    {
        speed *= 0.75f;
        jumpingPower *= 0.75f;
    }
}
