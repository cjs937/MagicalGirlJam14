using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth = 100;
    GameStateManager stateManager;
    HitFlash hitFlashComponent;
    void Start()
    {
        stateManager = FindAnyObjectByType<GameStateManager>();
        hitFlashComponent = GetComponent<HitFlash>();
    }

    public void TakeDamage(float damage)
    {
        hitFlashComponent.StartCoroutine(hitFlashComponent.SetHitFlash());
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            stateManager.GameOver();
        }
    }
}
