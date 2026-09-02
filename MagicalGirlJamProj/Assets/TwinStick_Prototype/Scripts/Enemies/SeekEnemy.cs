using UnityEngine;

public class SteeringEnemy : EnemyBase
{
    float maxSpeed = 5;

    protected override void DoMove()
    {
        Vector3 desiredVelocity = Vector3.Normalize(playerPos.position - transform.position) * moveSpeed;
        rigidBody.linearVelocity += (desiredVelocity - rigidBody.linearVelocity) * Time.deltaTime;
    }
}
