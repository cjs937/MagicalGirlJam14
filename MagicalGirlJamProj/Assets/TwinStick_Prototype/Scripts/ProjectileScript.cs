using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float timeAlive;

    void Start()
    {
        rb=GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
        timeAlive -= Time.fixedDeltaTime;

        if (timeAlive < 0)
            Destroy(gameObject);
    }

	private void OnCollisionEnter(Collision collision)
	{
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

        if (enemy != null)
        {
			enemy.hp--;
            if (enemy.hp <= 0)
                Destroy(enemy.gameObject);

            Destroy(gameObject);
		}
	}
}
