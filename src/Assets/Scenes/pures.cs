using UnityEngine;

public class pures : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int minCount = 5;
    [SerializeField] private int maxCount = 10;

    [SerializeField] private Vector3 spawnRange = new Vector3(0f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int spawnCount = Random.Range(minCount, maxCount + 1);

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                spawnRange.y,
                Random.Range(-spawnRange.z, spawnRange.z)
            );

            Instantiate(prefab, randomPos, Quaternion.identity);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
