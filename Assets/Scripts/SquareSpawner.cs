using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    public List<Transform> spawnPoints;
    public TimeManager timeManager;

    private float timeSinceLastSpawn = 0.0f;

    private List<Transform> shuffledSpawnPoints;
    private int currentSpawnIndex = 0;

    void Start()
    {
        ShuffleSpawnPoints();
    }

    void Update()
    {
        // Gère le temps global via TimeManager
        timeManager.UpdateTimer();

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= timeManager.spawnInterval)
        {
            timeSinceLastSpawn = 0.0f;
            SpawnSquare();
        }
    }

    void SpawnSquare()
    {
        if (shuffledSpawnPoints.Count > 0)
        {
            Transform spawnPoint = shuffledSpawnPoints[currentSpawnIndex];
            Instantiate(square, spawnPoint.position, spawnPoint.rotation);

            currentSpawnIndex++;

            if (currentSpawnIndex >= shuffledSpawnPoints.Count)
            {
                ShuffleSpawnPoints();
                currentSpawnIndex = 0;
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
