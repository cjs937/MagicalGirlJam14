using UnityEngine;

public class ChargeEnemy : EnemyBase
{
    public Vector2 chargeDelayRange = new Vector2(.5f, 3f);
    float currentDelay = 0f;
    float delayTimer = 0f;
    public float chargeForce = 10f;

    void StartNextDelay()
    {
        currentDelay = Random.Range(chargeDelayRange.x, chargeDelayRange.y);
        delayTimer = 0f;
    }
    protected override void DoMove()
    {
        delayTimer += Time.deltaTime;
        if (delayTimer >= currentDelay)
        {
            Vector3 chargeVec = Vector3.Normalize(playerPos.position - transform.position) * chargeForce;
            rigidBody.linearVelocity = Vector3.zero;
            rigidBody.AddForce(chargeVec);

            StartNextDelay();
        }
    }
}
