using UnityEngine;

public class Square : MonoBehaviour
{
    [Range(1, 2000)]
    public static float globalSpeed = 15f;
    public static float speedIncrease = 5f;

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
            speed = 0f;
            hasLanded = true;
            Debug.Log("Square landed and stopped.");
        }
    }

    public static void IncreaseGlobalSpeed()
    {
        globalSpeed += speedIncrease;
        Debug.Log("New global square speed: " + globalSpeed);
    }
}
