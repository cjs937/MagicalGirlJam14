using UnityEngine;
using System.Collections.Generic;
public class SlowTrigger : MonoBehaviour
{
    public float enemySpeed;
    public List<Transform> enemies;
    public List<float> enemyStartSpeed;

    private float timer;
    public float timeLimit = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count > 0)
        {
            timer += Time.deltaTime;

            if(timer >= timeLimit)
            {
                for(int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].GetComponent<EnemyScript>().speed = enemyStartSpeed[i];
                }

                this.gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Transform enemy = other.transform;
            enemies.Add(enemy);

            if(enemy.GetComponent<followPlayerEnemy>() != null)
            {
                enemy.GetComponent<followPlayerEnemy>().moveSpeed = 0.0f;
            }

            if(enemy.GetComponent<ChargeEnemy>() != null)
            {
                enemy.GetComponent<ChargeEnemy>().moveSpeed = 0.0f;
            }

            if(enemy.GetComponent<SeekEnemy>() != null)
            {
                enemy.GetComponent<SeekEnemy>().moveSpeed = 0.0f;
            }

            if(enemy.GetComponent<EnemyScript>() != null)
            {
                enemyStartSpeed.Add(enemy.GetComponent<EnemyScript>().speed);
                enemy.GetComponent<EnemyScript>().speed = 0;
            }
        }
    }
}
