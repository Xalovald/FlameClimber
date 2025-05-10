using UnityEngine;

public class Square : MonoBehaviour
{
    [Range(1, 2000)]
    public static float globalSpeed = 15f;
    public static float speedIncrease = 5f;
    public static float maxSpeed = 45f;

    private float speed;
    private bool hasLanded = false;

    void Start()
    {
        speed = globalSpeed;
    }

    void Update()
    {
        if (!hasLanded)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Square"))
        {
            hasLanded = true;
            speed = 0f;
        }
    }

    public static void IncreaseGlobalSpeed()
    {
        globalSpeed = Mathf.Min(globalSpeed + speedIncrease, maxSpeed);
    }
}
