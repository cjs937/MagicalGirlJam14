using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class SlotScript : GamblingScript
{
	[SerializeField] Sprite[] options;
	[SerializeField] Sprite winSprite;

	List<Image> slots;


	public override void Activate(GameObject player)
    {
		base.Activate(player);

		if (gambleView == null)
		{
			slots = new List<Image>();
			gambleView = Instantiate(uiPrefab, panel);

			foreach (Transform child in gambleView.transform)
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
		int rarity = 0;

		inProgress = false;
		for (int i = 1; i < slots.Count; i++)
			if (slots[i].sprite == winSprite)
				rarity++;

		int match = 0;
		if (slots[0].sprite == slots[1].sprite)
			match++;
		if (slots[1].sprite == slots[2].sprite)
			match++;
		if (slots[0].sprite == slots[2].sprite)
			match++;

		rarity = Mathf.Min(5, rarity + match);

		if (rarity > 0)
		{
<<<<<<< Updated upstream
			Win(Rarity.BulletTypeWin);
			for (int i = 0; i < winTime; i++)
=======
			Win((Rarity)rarity);
			for (int i = 0; i < rarity; i++)
>>>>>>> Stashed changes
			{
				inProgress = true;

				foreach (Image img in slots)
					img.color = Color.gold;
				await Task.Delay(500);

				foreach (Image img in slots)
					img.color = Color.black;
				await Task.Delay(500);
			}
		}
		else Loss();

		inProgress = false;
	}
}
