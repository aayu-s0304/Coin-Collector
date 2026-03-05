using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int coinsToSpawn = 10;
    [SerializeField] private float spawnHeightOffset = 0.5f;

    [Header("Spawn Area Settings")]
    [SerializeField] private string platformTag = "Platform";
    [SerializeField] private Vector2 randomOffsetRange = new Vector2(-2f, 2f);

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag(platformTag);

        if (platforms.Length == 0)
        {
            Debug.LogWarning("No objects found with tag: " + platformTag);
            return;
        }

        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject randomPlatform = platforms[Random.Range(0, platforms.Length)];
            Collider platformCollider = randomPlatform.GetComponent<Collider>();

            if (platformCollider == null)
            {
                Debug.LogWarning("Platform has no Collider: " + randomPlatform.name);
                continue;
            }

            Bounds bounds = platformCollider.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 spawnPos = new Vector3(randomX, bounds.max.y + spawnHeightOffset, randomZ);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}