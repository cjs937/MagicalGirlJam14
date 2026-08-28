using Unity.VisualScripting;
using UnityEngine;

public class followPlayer : EnemyBase
{
    public float moveSpeed = 5;
    public float stoppingDistance = 2;

    protected override void DoMove()
    {
        //transform.LookAt(playerPos);
        float distToPlayer = Vector3.Distance(playerPos.position, transform.position);
        float speed = Mathf.Lerp(moveSpeed, 0, Mathf.Min(1, distToPlayer / stoppingDistance));

        rigidBody.linearVelocity = Vector3.Normalize(playerPos.position - transform.position) * moveSpeed;
    }
}
