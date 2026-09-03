using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    public float health;
    public Vector2 randomHealth = new Vector2 (3f, 5f);
    EnemyManager manager;
    EnemyBase baseScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = Random.Range(randomHealth.x, randomHealth.y);
        manager = FindAnyObjectByType<EnemyManager>();
        baseScript = GetComponent<EnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Bullet" && other.transform.GetComponent<BulletCollisions>() != null)
        {
            Transform bullet = other.transform;
            string bulletType = other.transform.GetComponent<BulletCollisions>().bulletType;
            float bulletDamage = StatLibrary.Instance.attackPower;

            if(bulletType == "BASIC")
            {
                TakeDamage(bulletDamage);
                other.gameObject.SetActive(false);
            }

            if(bulletType == "KNOCKBACK")
            {
                if(transform.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody enemyRB = transform.GetComponent<Rigidbody>();
                    enemyRB.linearVelocity = new Vector3(0f, 0f, 0f);
                    enemyRB.AddForce(other.transform.forward * 6550f);
                }
                
                TakeDamage(bulletDamage);
                other.gameObject.SetActive(false);
            }

            if(bulletType == "CRITICAL")
            {
                int randomNum = Random.Range(0, 10);

                if(randomNum == 1)
                {
                    //Debug.Log("Critical Kill");
                    TakeDamage(1000f);
                }
                else
                {
                    //Debug.Log("Basic Shot");
                    TakeDamage(bulletDamage);
                }
                
                other.gameObject.SetActive(false);
            }

            if(bulletType == "SLOW")
            {
                TakeDamage(bulletDamage);
                other.gameObject.SetActive(false);
            }

            if(bulletType == "EXPLOSIVE")
            {
                TakeDamage(bulletDamage);
                other.gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;//transform.GetComponent<EnemyScript>().hp -= 1;
        transform.GetComponent<HitFlash>().StartCoroutine(transform.GetComponent<HitFlash>().SetHitFlash()); //Make enemy flash
        KillEnemy();
    }

    public void KillEnemy()
    {
        if(health <= 0f)
        {
            //player.GetComponent<TopDownKillCounter>().killCount += 1f;
            //gameObject.SetActive(false);
            if(manager)
                manager.RemoveEnemy(baseScript);
            else
                Destroy(gameObject);
            
        }
    }
}
