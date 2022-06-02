using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public int spawnIndex;
    public float yLocation;
    public float spawnRate;
    public Vector3 spawnLocation;

    public Vector3 spawnOffset;
    public bool isMovingSpawner = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = new Vector3(transform.position.x, yLocation, transform.position.z);
        spawnLocation += spawnOffset;
        SpawnEnemy();
        StartCoroutine(SpawnRoutine());

    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        if (isMovingSpawner)
        {
            spawnLocation = new Vector3(transform.position.x, yLocation, transform.position.z);
            spawnLocation += spawnOffset;
        }
        spawnIndex = UnityEngine.Random.Range(0, enemy.Length);
        Instantiate(enemy[spawnIndex], spawnLocation, Quaternion.identity);
    }
}
