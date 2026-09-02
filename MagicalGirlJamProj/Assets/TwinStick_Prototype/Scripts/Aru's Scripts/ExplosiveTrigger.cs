using UnityEngine;

public class ExplosiveTrigger : MonoBehaviour
{
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && other.transform.GetComponent<EnemyCollisions>() != null)
        {
            other.transform.GetComponent<EnemyCollisions>().TakeDamage(damage);
        }
    }
}
