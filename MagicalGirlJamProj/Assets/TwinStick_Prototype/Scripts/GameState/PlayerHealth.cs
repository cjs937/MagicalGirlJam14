using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float currentHealth = 100;
    GameStateManager stateManager;

    void Start()
    {
        stateManager = FindAnyObjectByType<GameStateManager>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            stateManager.GameOver();
        }
    }
}
