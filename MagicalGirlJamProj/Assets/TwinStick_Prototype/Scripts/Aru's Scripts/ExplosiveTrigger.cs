using UnityEngine;

public class ExplosiveTrigger : MonoBehaviour
{
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && other.transform.GetComponent<EnemyCollisions>() != null)
        {
            other.transform.GetComponent<EnemyCollisions>().TakeDamage(damage);
        }
    }
}
