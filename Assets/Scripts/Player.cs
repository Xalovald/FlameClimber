using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float baseMoveSpeed;
    public float jumpForce = 10f;
    public bool isJumping;
    public bool isGrounded;
    public bool isBlockAbove;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform headCheckRight;
    public Transform headCheckLeft;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public int coinCount = 0;

    public TextMeshProUGUI bonusText;

    void Start()
    {
        baseMoveSpeed = moveSpeed;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isBlockAbove = Physics2D.OverlapArea(headCheckLeft.position, headCheckRight.position);
        foreach (ContactPoint2D contact in collision.contacts)
        {

            if (isBlockAbove && collision.collider.CompareTag("Square"))
            {
                Die();
                break;
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // === MÉTHODES DE BONUS ===
    public void AddCoin()
    {
        coinCount++;
        UpdateBonusText();
    }

    void UpdateBonusText()
    {
        bonusText.text = "Pièces : " + coinCount;
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
