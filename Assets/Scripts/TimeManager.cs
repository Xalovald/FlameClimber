using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float spawnInterval = 2.0f;
    public float decreaseAmount = 0.1f;
    public float decreaseInterval = 5.0f;
    public float minimumSpawnInterval = 0.5f;

    private float timer = 0.0f;

    public void UpdateTimer()
    {
        timer += Time.deltaTime;

        if (timer >= decreaseInterval)
        {
            timer = 0f;
            DecreaseSpawnIntervalAndNotifySquare();
        }
    }

    private void DecreaseSpawnIntervalAndNotifySquare()
    {
        if (spawnInterval > minimumSpawnInterval)
        {
            spawnInterval -= decreaseAmount;
            spawnInterval = Mathf.Max(spawnInterval, minimumSpawnInterval);
        }

        Square.IncreaseGlobalSpeed();
    }
}
