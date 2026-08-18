using System.Threading.Tasks;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Transform player;
    Rigidbody rb;

    bool launched = false;

    public float speed;
    public int hp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (launched) return;
        rb.linearVelocity = Vector3.Normalize(player.position - transform.position) * speed;
    }

	public async void Launch(Vector3 dir)
    {
        launched = true;

        rb.linearVelocity = dir;
        await Task.Delay(1000);
		launched = false;
	}
}
