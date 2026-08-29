using Unity.VisualScripting;
using UnityEngine;

public class followPlayerEnemy : EnemyBase
{
    public float moveSpeed = 5f;
    public float stoppingDistance = 2f;
    protected override void DoMove()
    {
        //transform.LookAt(playerPos);
        float distToPlayer = Vector3.Distance(playerPos.position, transform.position);
        float speed = distToPlayer > stoppingDistance ? moveSpeed : 0.0f; 

        rigidBody.linearVelocity = Vector3.Normalize(playerPos.position - transform.position) * speed;
    }
}
