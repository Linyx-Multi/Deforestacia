using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Variables for different parts of the script, the names should explain enough, yeeeessss....?

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    // Cereal-ized Fields.. got a transformed, rigid mask..
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
 
    // OncePerFrame update check for if playercharacter needs flip, oh and jumping.. thats probably important.. i think?
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Returns either 1, 0 or -1

        Flip(); // DO A FLIP!
    }

    // FixedUpdate checks for speed and horizontal movement and translates to velocity. *MATH*
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if(Input.GetButtonDown("Jump") && IsGrounded()) // no double-jumping, hopefully..
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // jump in a direction, maybe?
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // Gets X velo, and Y velo and multiplies by 0.5, jump high by holding.
        }
    }

    // are YOU grounded?
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
}