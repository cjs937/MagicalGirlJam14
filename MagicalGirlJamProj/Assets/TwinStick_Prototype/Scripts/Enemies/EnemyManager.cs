using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyBase> enemyTypes;
    public int maxEnemies = 30;
    public List<EnemyBase> currEnemies;
    public List<Transform> spawnPoints;
    public List<Vector2> spawnCurve; //after x seconds, change spawn rate to y
    float spawnTimer = 0;
    float lastSpawnTime = 0;

    public int curveIndex = 0;
    public int killCount = 0;

    void Update()
    { 

        if(currEnemies.Count < maxEnemies && Time.time >= lastSpawnTime + spawnCurve[curveIndex].y)
        {
            SpawnNewEnemy();
            lastSpawnTime = Time.time;
        }

        if(curveIndex < spawnCurve.Count - 1 && spawnTimer >= spawnCurve[curveIndex + 1].x)
        {
            ++curveIndex;
        }

        spawnTimer += Time.deltaTime;
    }

    void SpawnNewEnemy()
    {
        EnemyBase enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        EnemyBase newEnemy = Instantiate(enemyType);
        newEnemy.transform.position = spawnPoint.position;
        currEnemies.Add(newEnemy);
    }

    public void RemoveEnemy(EnemyBase enemy)
    {
        currEnemies.Remove(enemy);
        Destroy(enemy.gameObject);
        ++killCount;
    }

    public void StopAllEnemies()
    {
        foreach(EnemyBase enemy in currEnemies)
        {
            enemy.gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
