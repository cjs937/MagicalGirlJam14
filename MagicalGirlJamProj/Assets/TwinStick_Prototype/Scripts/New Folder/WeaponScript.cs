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
		EnemyScript enemy=go.GetComponent<EnemyScript>();
		
		if (enemy != null) 
			enemy.Launch((go.transform.position - owner.position) * hitForce);
	}
}
