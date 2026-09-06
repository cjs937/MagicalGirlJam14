using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    public float health;
    public Vector2 randomHealth = new Vector2 (3f, 5f);
    public Transform deathParticle;

    EnemyManager manager;
    EnemyBase baseScript;
    StatLibrary StatsManager;

    [Header("Audio Clips")]
    public AudioSource audioSource;
    public AudioClip[] clips;
    public float clipVolume = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = (int) Random.Range(randomHealth.x, randomHealth.y);
        manager = FindAnyObjectByType<EnemyManager>();
        baseScript = GetComponent<EnemyBase>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();

        GameObject statman = GameObject.FindGameObjectWithTag("StatsManager");
        StatsManager = statman.GetComponent<StatLibrary>();
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
            //float bulletDamage = other.transform.GetComponent<BulletCollisions>().bulletDamage;
            float bulletDamage = StatLibrary.Instance.attackPower;

            if(clips.Length > 0 && audioSource != null)
            {
                audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)], clipVolume);
                //transform.GetComponent<AudioSource>().pitch = Random.Range(0.65f, 1.1f);
                //transform.GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0, clips.Length)], clipVolume);
            }
            
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
            StatsManager.Gold += 5;

            if(deathParticle != null)
            {
                Transform activeParticle = Instantiate(deathParticle, transform.position, transform.rotation);
                activeParticle.gameObject.SetActive(true);
            }
            
            if(manager)
                manager.RemoveEnemy(baseScript);
            else
            {
                Destroy(gameObject);
            }
                
            
        }
    }
}
