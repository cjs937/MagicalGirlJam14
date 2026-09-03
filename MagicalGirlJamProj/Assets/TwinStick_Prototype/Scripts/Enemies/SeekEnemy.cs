using UnityEngine;

public class SeekEnemy : EnemyBase
{
    //float maxSpeed = 5;

    protected override void DoMove()
    {
        Vector3 desiredVelocity = Vector3.Normalize(playerPos.position - transform.position) * moveSpeed * Time.deltaTime;
        rigidBody.linearVelocity += desiredVelocity;//(desiredVelocity - rigidBody.linearVelocity) * Time.deltaTime;
    }
}
