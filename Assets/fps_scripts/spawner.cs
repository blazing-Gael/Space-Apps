using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab of the enemy to spawn
    public Vector3 spawnAreaSize;    // Size of the area where enemies will spawn
    public float spawnAreaRadius;
    public int enemyCount = 10;      // Number of enemies to spawn
    public float spawnDelay = 2.0f;  // Delay between spawns (optional)

    void Start()
    {
        StartCoroutine(SpawnEnemies()); // Start spawning enemies when the game starts
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay); // Wait before spawning the next enemy
        }
    }

    void SpawnEnemy()
    {
        // Get a random position within the spawn area
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Instantiate the enemy at the random position
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }

    void _SpawnEnemy()
    {
        Vector2 randomPosInCircle = Random.insideUnitCircle * spawnAreaRadius;
        Vector3 randomPosition = new Vector3(randomPosInCircle.x, transform.position.y, randomPosInCircle.y);
    
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
