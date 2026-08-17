using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class SlotScript : MonoBehaviour
{
	[SerializeField] GameObject slotPrefab;
	[SerializeField] RectTransform panel;
	[SerializeField] Sprite[] options;

	[SerializeField] List<Image> slots;
	GameObject mySlot;

	public bool canPull, spinning;
	float timeOnScreen;
	bool haveChecked;
		
    void Start()
    {

    }

	private void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.tag=="Player")
            canPull = true;
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag=="Player")
            canPull = false;
	}

	public void Pull()
    {
		if (!canPull || spinning) return;
		spinning = true;

		if (mySlot == null)
		{
			slots = new List<Image>();
			mySlot = Instantiate(slotPrefab, panel);

			foreach (Transform child in mySlot.transform)
				foreach (Transform child2 in child)
					slots.Add(child2.GetComponent<Image>());
		}

		Spin();
    }

	async void Spin()
	{
		for (float i = 0; i < 3; i += .1f)
		{
			foreach (Image img in slots)
				img.sprite = options[Random.Range(0, slots.Count)];

			await Task.Delay(100);
		}
		
		for (float i = 0; i < 1; i += .5f)
		{
			foreach (Image img in slots)
				img.sprite = options[Random.Range(0, slots.Count)];

			await Task.Delay(500);
		}

		foreach (Image img in slots)
			img.sprite = options[Random.Range(0, slots.Count)];

		CheckRewards();
	}

	async void CheckRewards()
	{
		spinning = false;
		for (int i = 1; i < slots.Count; i++)
			if (slots[0].sprite != slots[i].sprite) return;

		while (!spinning)
		{
			foreach (Image img in slots)
				img.color = Color.gold;
			await Task.Delay(500);

			foreach (Image img in slots)
				img.color = Color.black;
			await Task.Delay(500);
		}
	}

	private void Update()
	{
		if (!spinning && mySlot != null)
			timeOnScreen += Time.deltaTime;
		else
			timeOnScreen = 0;

		if (timeOnScreen>10)
			if (mySlot != null)
				Destroy(mySlot.gameObject);
	}
}
