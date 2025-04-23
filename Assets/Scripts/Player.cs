using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;
    public bool isBlockAbove;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform headCheckRight;
    public Transform headCheckLeft;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        isBlockAbove = Physics2D.OverlapArea(headCheckLeft.position, headCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }

        if(isBlockAbove == true)
        {
            Die();
        }

        MovePlayer(horizontalMovement);
        
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);
        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void Die()
    {
        Debug.Log("Le joueur à été touché!");
        Destroy(gameObject);
    }
}
