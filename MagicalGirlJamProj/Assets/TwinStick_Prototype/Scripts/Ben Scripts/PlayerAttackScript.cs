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
	public Slider magicSlider;
	public Slider magicDebtSlider;
	public Slider magicOverfillSlider;

	void Start()
	{
		animator = GetComponent<Animator>();
	}
	/*
	void OnAttackA()
	{
		if (magic <= 0) return;

		GameObject bullet = Instantiate(bulletPrefab);
		bullet.transform.position = transform.position;
		bullet.transform.up = transform.forward;
		magic -= 5;
	}
	*/
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
		//ManageMagicSliders();
	}

	void ManageMagicSliders()
	{
		magicOverfillSlider.maxValue = StatLibrary.Instance.maxMagic;
		magicDebtSlider.maxValue = StatLibrary.Instance.maxMagic;
		magicSlider.maxValue = StatLibrary.Instance.maxMagic;

		if (StatLibrary.Instance.magic < 0)
		{
			magicDebtSlider.gameObject.SetActive(true);
			magicDebtSlider.value = Mathf.Min(Mathf.Abs(StatLibrary.Instance.magic), StatLibrary.Instance.maxMagic);
		}
		else
		{
			magicDebtSlider.gameObject.SetActive(false);
			magicSlider.value = Mathf.Min(StatLibrary.Instance.magic, StatLibrary.Instance.maxMagic);

			if (StatLibrary.Instance.magic > StatLibrary.Instance.maxMagic)
			{
				magicOverfillSlider.gameObject.SetActive(true);
				magicOverfillSlider.value = Mathf.Min(StatLibrary.Instance.magic-StatLibrary.Instance.maxMagic, StatLibrary.Instance.maxMagic);
			}
			else
				magicOverfillSlider.gameObject.SetActive(false);
		}
	}
}
