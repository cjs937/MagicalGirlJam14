using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    public int bulletDamage;
    public string bulletType;
    public Transform spawnOnDeath;

    public float lifeTime = 3f;
    public GameObject OnHitFX;
    private void Start()
    {
        Invoke(nameof(DestroyBullet), lifeTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
            return;

        if (other.CompareTag("Enemy"))
            return;

        DestroyBullet();
        */
    }

    void DestroyBullet()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, 0f, transform.position.z);
        if (spawnOnDeath)
        { 
            Transform deathEffect= Instantiate(spawnOnDeath, spawnPos, spawnOnDeath.rotation);
            deathEffect.gameObject.SetActive(true);
        }

        GameObject onHitFX = Instantiate(OnHitFX, spawnPos, OnHitFX.transform.rotation);
        
        Destroy(gameObject);
    }
}
