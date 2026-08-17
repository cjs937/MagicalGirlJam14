using System.Threading.Tasks;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Transform player;
    Rigidbody rb;

    bool canMove = true;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (!canMove) return;
        rb.linearVelocity = Vector3.Normalize(player.position - transform.position) * speed;
    }

    public async void Launch(Vector3 dir)
    {
        canMove = false;

        rb.linearVelocity = dir;
        await Task.Delay(1000);
        canMove = true;
	}
}
