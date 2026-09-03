using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth = 100;
    GameStateManager stateManager;
    HitFlash hitFlashComponent;
    private HP_UI healthBar;
    void Start()
    {
        stateManager = FindAnyObjectByType<GameStateManager>();
        hitFlashComponent = GetComponent<HitFlash>();
        healthBar = FindAnyObjectByType<HP_UI>();
        healthBar.SetMax_HP(currentHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        hitFlashComponent.StartCoroutine(hitFlashComponent.SetHitFlash());
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            stateManager.GameOver();
        }
    }
}
