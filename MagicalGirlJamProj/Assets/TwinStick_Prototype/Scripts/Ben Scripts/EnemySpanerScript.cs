using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanerScript : MonoBehaviour
{
    public int difficulty;
    public float spawnTime;
    float timeUntilNextSpawn;
    [SerializeField] GameObject[] enemyPrefabs;
    List<GameObject> enemies = new List<GameObject>();

    public Vector2 maxSpawnPosition;

    void Start()
    {
        timeUntilNextSpawn = spawnTime;
        for (int i = 0; i < 4; i++)
            SpawnEnemy(0);
    }

	private void Update()
	{
		timeUntilNextSpawn -= Time.deltaTime;

        if (timeUntilNextSpawn < 0 )
        {
            timeUntilNextSpawn = spawnTime;
            SpawnEnemy(difficulty);
        }
	}

	public void SpawnEnemy(int maxDifficulty)
    {
        Transform newEnemy=Instantiate(enemyPrefabs[Random.Range(0, maxDifficulty)]).transform;
        newEnemy.transform.position = new Vector3(Random.Range(-maxSpawnPosition.x, maxSpawnPosition.x), 1, Random.Range(-maxSpawnPosition.y, maxSpawnPosition.y));
        newEnemy.gameObject.SetActive(true);
    }
}
