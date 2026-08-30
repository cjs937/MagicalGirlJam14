using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EnemyBase : MonoBehaviour
{
    protected Transform playerPos;
    protected Rigidbody rigidBody;
    float baseSpeed;
    bool launched;
    public float moveSpeed = 5f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerPos = FindAnyObjectByType<PlayerMovementScript>().transform; //GameObject.FindWithTag("Player").transform;
    }

    protected virtual void DoMove()
    {}

    void FixedUpdate()
    {
        if(!launched)
            DoMove();
    }

    public async void Launch(Vector3 dir)
    {
        launched = true;

        rigidBody.linearVelocity = dir;
        await Task.Delay(1000);
        launched = false;
    }
}
