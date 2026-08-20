using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RouletteScript : GamblingScript
{
	float currentSpin;
	public float spinSpeed;
	List<Transform> pockets;

    void Start()
    {

    }

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
		while (currentSpin > .5f)
		{
			gambleView.transform.eulerAngles += new Vector3(0, 0, currentSpin * Time.deltaTime);
			spinTime+=Time.deltaTime;
			await Task.Yield();

			if (spinTime > 3)
				currentSpin -= currentSpin*Time.deltaTime;
		}

		spinTime = 0;
		float angle = gambleView.transform.eulerAngles.z % 360;
		float finalAngle = Mathf.CeilToInt(angle / 360 * pockets.Count)*(360 / pockets.Count);

		while (spinTime < 1f)
		{
			gambleView.transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(angle, finalAngle, Time.deltaTime*100));
			spinTime += Time.deltaTime;
		}

		inProgress = false;
	}
}
