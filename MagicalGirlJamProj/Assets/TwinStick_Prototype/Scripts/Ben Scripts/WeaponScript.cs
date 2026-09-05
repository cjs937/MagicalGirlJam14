using UnityEngine;

public class WeaponScript : MonoBehaviour
{
	Transform owner;
	public float hitForce;

	void Start()
	{
		owner = transform.root;	
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Enemy")
			Hit(collider.gameObject);
	}

	void Hit(GameObject go)
	{
		EnemyBase enemy=go.GetComponent<EnemyBase>();
		
		if (enemy != null) 
			enemy.Launch((go.transform.position - owner.position) * hitForce);
	}
}
