using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class RouletteScript : GamblingScript
{
	int pocketIndex;
	float currentSpin;
	GameObject spinner;
	public float spinSpeed;
	
	float pocketSize;
	List<Transform> pockets;

	public override void Activate(GameObject player)
	{
		base.Activate(player);

		if (gambleView == null)
		{
			gambleView = Instantiate(uiPrefab, panel);
			spinner = gambleView.transform.GetChild(0).gameObject;
			spinner.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 18) * 20);

			pockets = new List<Transform>();

			foreach (Transform child in spinner.transform)
				pockets.Add(child);
		}

		pocketSize = 360f / pockets.Count;
		currentSpin = spinSpeed;
		Spin();
	}

	async void Spin()
	{
		float spinTime = 0;
		currentSpin *= Random.Range(.75f, 5f);

		while (currentSpin > .5f)
		{
			spinner.transform.eulerAngles += new Vector3(0, 0, currentSpin * Time.deltaTime);
			spinTime += Time.deltaTime;
			await Task.Yield();

			if (spinTime > 3)
				currentSpin -= currentSpin * Time.deltaTime;
		}

		float angle = spinner.transform.eulerAngles.z;
		float cAngle = (360 - angle) % 360;

		pocketIndex = Mathf.FloorToInt(((cAngle + pocketSize / 2) / pocketSize) % pockets.Count);
		float finalAngle = pocketIndex * pocketSize;

		while (spinTime < 1f)
		{
			spinner.transform.rotation = Quaternion.Slerp(spinner.transform.rotation, Quaternion.Euler(0, 0, finalAngle), Time.deltaTime);
			spinTime += Time.deltaTime;
			await Task.Yield();
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
