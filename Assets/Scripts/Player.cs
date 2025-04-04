using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    private OnTriggerHead onTriggerHead;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        onTriggerHead = GetComponent<OnTriggerHead>();
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
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

    public void Die()
    {
        if (onTriggerHead != null && onTriggerHead.headTrigger)
        {
            Destroy(gameObject);
            Debug.Log("Player has been destroyed!");
        }
    }
}
