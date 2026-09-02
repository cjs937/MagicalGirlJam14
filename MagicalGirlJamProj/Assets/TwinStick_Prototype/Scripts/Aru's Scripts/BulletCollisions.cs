using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    public int bulletDamage;
    public string bulletType;
    public Transform spawnOnDeath;

    public float lifeTime = 3f;

    private void Start()
    {
        Invoke(nameof(DestroyBullet), lifeTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.tag != "Bullet")
            DestroyBullet();
    }

    void DestroyBullet()
    {
        if(spawnOnDeath)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, 0f, transform.position.z);

            Transform deathEffect= Instantiate(spawnOnDeath, spawnPos, spawnOnDeath.rotation);
            deathEffect.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }
}
