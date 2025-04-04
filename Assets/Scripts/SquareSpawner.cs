using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    public List<Transform> spawnPoints;
    public float spawnInterval = 2.0f;
    private float timeSinceLastSpawn = 0.0f;

    private List<Transform> shuffledSpawnPoints;
    private int currentSpawnIndex = 0;
    private Transform lastSpawnPoint = null;
    private int consecutiveSpawns = 0;

    void Start()
    {
        ShuffleSpawnPoints();
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0.0f;
            SpawnSquare();
        }
    }

    void SpawnSquare()
    {
        if (shuffledSpawnPoints.Count > 0)
        {
            Transform spawnPoint;
            do
            {
                spawnPoint = shuffledSpawnPoints[currentSpawnIndex];
                currentSpawnIndex = (currentSpawnIndex + 1) % shuffledSpawnPoints.Count;
            } while (spawnPoint == lastSpawnPoint && consecutiveSpawns >= 2);

            Instantiate(square, spawnPoint.position, spawnPoint.rotation);

            if (spawnPoint == lastSpawnPoint)
            {
                consecutiveSpawns++;
            }
            else
            {
                lastSpawnPoint = spawnPoint;
                consecutiveSpawns = 1;
            }
            if (currentSpawnIndex == 0)
            {
                ShuffleSpawnPoints();
            }
        }
    }

    void ShuffleSpawnPoints()
    {
        shuffledSpawnPoints = new List<Transform>(spawnPoints);

        for (int i = shuffledSpawnPoints.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Transform temp = shuffledSpawnPoints[i];
            shuffledSpawnPoints[i] = shuffledSpawnPoints[j];
            shuffledSpawnPoints[j] = temp;
        }
    }
}
