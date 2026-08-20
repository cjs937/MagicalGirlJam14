using System.Reflection.PortableExecutable;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackScript : MonoBehaviour
{
	Animator animator;
	public GameObject bulletPrefab;
	[SerializeField] GameObject spawner;
	[SerializeField] GameObject tutorial;

	[Header("Magic")]
	public float magic;
	public int maxMagic;
	public Slider magicSlider;
	public Slider magicDebtSlider;
	public Slider magicOverfillSlider;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void OnAttackA()
	{
		if (magic <= 0) return;

		GameObject bullet = Instantiate(bulletPrefab);
		bullet.transform.position = transform.position;
		bullet.transform.up = transform.forward;
		magic -= 5;
	}

	void OnAttackB()
	{
		animator.Play("swing");
	}
	void OnInteract()
	{
		foreach (GamblingScript gamble in FindObjectsByType<GamblingScript>())
			gamble.TryActivate(gameObject);
	}

	private void Update()
	{
		ManageMagicSliders();
	}

	void ManageMagicSliders()
	{
		magicOverfillSlider.maxValue = maxMagic;
		magicDebtSlider.maxValue = maxMagic;
		magicSlider.maxValue = maxMagic;

		if (magic < 0)
		{
			magicDebtSlider.gameObject.SetActive(true);
			magicDebtSlider.value = Mathf.Min(Mathf.Abs(magic), maxMagic);
		}
		else
		{
			magicDebtSlider.gameObject.SetActive(false);
			magicSlider.value = Mathf.Min(magic, maxMagic);

			if (magic > maxMagic)
			{
				magicOverfillSlider.gameObject.SetActive(true);
				magicOverfillSlider.value = Mathf.Min(magic-maxMagic, maxMagic);
			}
			else
				magicOverfillSlider.gameObject.SetActive(false);
		}
	}
}
