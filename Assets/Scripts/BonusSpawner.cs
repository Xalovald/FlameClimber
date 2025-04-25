using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject bonusCoin;

    public float bonusSpawnDelay = 5f;
    public float bonusSpawnInterval = 3f;

    private float timeSinceStart = 0f;
    private float timeSinceLastBonus = 0f;

    public List<Transform> bonusSpawnPoints;

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        timeSinceLastBonus += Time.deltaTime;

        if (timeSinceStart >= bonusSpawnDelay && timeSinceLastBonus >= bonusSpawnInterval)
        {
            timeSinceLastBonus = 0f;
            SpawnBonus();
        }
    }

    void SpawnBonus()
    {
        if (bonusSpawnPoints.Count == 0) return;

        Transform spawnPoint = bonusSpawnPoints[Random.Range(0, bonusSpawnPoints.Count)];

        GameObject bonusPrefab = GetRandomBonusPrefab();

        if (bonusPrefab != null)
        {
            Instantiate(bonusPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    GameObject GetRandomBonusPrefab()
    {
        return bonusCoin;
    }
}
