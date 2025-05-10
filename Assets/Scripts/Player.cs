using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float moveSpeed = 250f;
    private float baseMoveSpeed;
    public float jumpForce = 450f;
    public bool isJumping;
    public bool isGrounded;
    public bool isBlockAbove;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform headCheckRight;
    public Transform headCheckLeft;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    public int coinCount = 0;

    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI blockSpeedText;
    public TextMeshProUGUI playerSpeedText;

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

        flip(rb.linearVelocity.x);

        bool characterJump = isJumping;
        animator.SetBool("IsJump", characterJump);

        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", characterVelocity);

        UpdateBlockSpeedText();
        UpdatePlayerSpeedText();
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

    void flip(float velocity)
    {
        if(velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
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
        GameManager gm = FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            float timeSurvived = Time.timeSinceLevelLoad;
            gm.TriggerGameOver(coinCount, timeSurvived);
        }

        Destroy(gameObject);
    }


    // MÉTHODES DE BONUS //
    public void AddCoin()
    {
        coinCount++;
        UpdateBonusText();
    }

    public void BoostSpeed(float amount)
    {
        moveSpeed += amount;
        UpdatePlayerSpeedText();
    }


    // MÉTHODES DE TEXTE //
    void UpdateBonusText()
    {
        bonusText.text = "Coins : " + coinCount;
    }
    void UpdateBlockSpeedText()
    {
        blockSpeedText.text = "Block speed : " + Square.globalSpeed.ToString("0.0");
    }

    void UpdatePlayerSpeedText()
    {
        playerSpeedText.text = "Player speed : " + moveSpeed.ToString("0.0");
    }

}
