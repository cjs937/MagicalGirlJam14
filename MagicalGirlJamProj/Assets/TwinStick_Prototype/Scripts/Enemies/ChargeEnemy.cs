using UnityEngine;

public class ChargeEnemy : EnemyBase
{
    public Vector2 chargeDelayRange = new Vector2(.5f, 3f);
    float currentDelay = 0f;
    float delayTimer = 0f;
    public float chargeForce = 10f;
    bool charging = false;
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
            rigidBody.linearVelocity = Vector3.zero;
            if (!charging)
            {
                Vector3 chargeVec = Vector3.Normalize(playerPos.position - transform.position) * chargeForce;

                rigidBody.AddForce(chargeVec);

                charging = true;
            }
            else
                charging = false;

            StartNextDelay();
        }
    }
}
