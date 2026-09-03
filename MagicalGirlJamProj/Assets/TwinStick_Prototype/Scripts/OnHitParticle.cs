using UnityEngine;

public class OnHitParticle : MonoBehaviour
{
    public float lifeTime = .2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(DeleteSelf), lifeTime);
    }

    void DeleteSelf()
    {
        Destroy(gameObject);
    }
}
