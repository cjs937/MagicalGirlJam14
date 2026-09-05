using UnityEngine;
using System.Collections.Generic;

public class DamagePlayer : MonoBehaviour
{
    //public Collider collision;
    public bool continuousOverlap = false;
    PlayerHealth playerHealth;
    public float damageCooldown = 1.0f;
    float lastDamageTime = 0;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        if(continuousOverlap && playerHealth)
        {
            DoDamage(damage, playerHealth);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        playerHealth = other.transform.GetComponent<PlayerHealth>();
        if(!continuousOverlap && playerHealth)
        {
            DoDamage(damage, playerHealth);
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if(playerHealth && other.gameObject == playerHealth.gameObject)
        {
            playerHealth = null;
        }
    }

    void DoDamage(float damage, PlayerHealth player)
    {
        if (Time.time >= lastDamageTime + damageCooldown)
        {
            player.TakeDamage(damage);
            lastDamageTime = Time.time;
        }
    }
}
