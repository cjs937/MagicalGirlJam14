using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class RouletteScript : GamblingScript
{
	int pocketIndex;
	float currentSpin;
	public float spinSpeed;
	List<Transform> pockets;

	public override void Activate(GameObject player)
	{
		base.Activate(player);

		if (gambleView == null)
		{
			gambleView = Instantiate(uiPrefab, panel);
			gambleView = gambleView.transform.GetChild(0).gameObject;
			gambleView.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 18) * 20);

			pockets = new List<Transform>();

			foreach (Transform child in gambleView.transform)
				pockets.Add(child);
		}

		currentSpin = spinSpeed;
		Debug.Log(gambleView);
		Spin();
	}

	async void Spin()
	{
		float spinTime = 0;
		currentSpin *= Random.Range(.75f, 5f);

		while (currentSpin > .5f)
		{
			gambleView.transform.eulerAngles += new Vector3(0, 0, currentSpin * Time.deltaTime);
			spinTime += Time.deltaTime;
			await Task.Yield();

			if (spinTime > 3)
				currentSpin -= currentSpin * Time.deltaTime;
		}

		spinTime = 0;
		float angle = gambleView.transform.eulerAngles.z % 360;
		pocketIndex = Mathf.CeilToInt(angle / 360 * pockets.Count);
		float finalAngle = pocketIndex * (360 / pockets.Count);

		while (spinTime < 1f)
		{
			gambleView.transform.rotation = Quaternion.Slerp(gambleView.transform.rotation, Quaternion.Euler(0,0,finalAngle), Time.deltaTime);
			spinTime += Time.deltaTime;
		}

		inProgress = false;
		CheckRewards();
	}

	void CheckRewards()
	{
		string pocketName = pockets[pocketIndex].name;
		if (pocketName.Contains("B"))
			Win(Rarity.BulletModeWin);
		else if (pocketName.Contains("G"))
			Win(Rarity.BigBulletModeWin);
		else Loss();
	}
}
