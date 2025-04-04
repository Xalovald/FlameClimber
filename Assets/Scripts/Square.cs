using UnityEngine;

public class Square : MonoBehaviour
{
    [Range(15, 60)]
    public float speed = 15;
    public float speedIncreaseAmount = 5;

    private float timeSinceLastIncrease = 0.0f;
    private float increaseInterval = 10.0f;

    void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= increaseInterval)
        {
            timeSinceLastIncrease = 0.0f;
            IncreaseSpeed();
        }

        // Example movement logic (optional)
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseSpeed()
    {
        speed += speedIncreaseAmount;
        speed = Mathf.Clamp(speed, 15, 50); // Ensure speed stays within the specified range
        Debug.Log("Speed increased to: " + speed);
    }
}
