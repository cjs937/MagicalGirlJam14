using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CrapsScript : GamblingScript
{
	public static int run;
	bool rolling1, rolling2;
	public Image die1, die2;
    [SerializeField] List<Sprite> dieFaces;

    void Start()
    {
        
    }

	public override void Activate(GameObject player)
	{
		base.Activate(player);

		if (gambleView == null)
		{
			gambleView = Instantiate(uiPrefab, panel);
			die1 = gambleView.transform.Find("Die1").GetComponent<Image>();
			die2 = gambleView.transform.Find("Die2").GetComponent<Image>();
		}

		rolling1 = true;
		rolling2 = true;
		Roll(die1);
		Roll(die2);
	}

	async void Roll(Image die)
	{
		float rollTime = Random.Range(1, 3);
		for (float i = 0; i < rollTime; i += .1f)
		{
			die.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
			die.sprite = dieFaces[Random.Range(0, dieFaces.Count)];
			await Task.Delay(Random.Range(0, 100));
		}

		for (float i = 0; i < 1; i += .5f)
		{
			die.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
			die.sprite = dieFaces[Random.Range(0, dieFaces.Count)];
			await Task.Delay(Random.Range(250, 500));
		}

		if (die == die1) rolling1 = false;
		if (die == die2) rolling2 = false;
		if (!rolling1 && !rolling2)
		{
			inProgress = false;
			CheckRewards();
		}
	}

	void CheckRewards()
	{
		int face1 = dieFaces.IndexOf(die1.sprite) + 1;
		int face2 = dieFaces.IndexOf(die2.sprite) + 1;
		int total = face1 + face2;

		if (total - 7 <= 0)
			Loss();
		else
		{
			int winnings = total - 7;
			
			if (die1.sprite == die2.sprite)
				winnings++;

			winnings = Mathf.Min(winnings, 5);
			Win((Rarity)winnings);
		}
	}
}
