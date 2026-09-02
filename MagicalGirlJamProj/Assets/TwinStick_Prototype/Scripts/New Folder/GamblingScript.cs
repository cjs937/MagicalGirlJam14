using UnityEngine;

public class GamblingScript : MonoBehaviour
{
	// UI
	[HideInInspector] public GameObject gambleView;
	public RectTransform panel;
	public GameObject uiPrefab;
	float timeOnScreen;

	// functionality
	public bool canPull, inProgress;
	public int winTime = 5;
	public int cost;
	PlayerBulletFire RewardRef;
	StatLibrary StatsManager;

	//Player Scripts
	public GameObject user;

	public enum Rarity {StatWin,BulletTypeWin,BulletModeWin,BigBulletModeWin};

	private void Update()
	{
		if (!inProgress && gambleView != null)
			timeOnScreen += Time.deltaTime;
		else
			timeOnScreen = 0;

		if (timeOnScreen > 10)
			if (gambleView != null)
				Destroy(gambleView.gameObject);
	}

	//Are we close enough to use this
	private void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
			canPull = true;
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
			canPull = false;
	}

	public void TryActivate(GameObject player)
	{
		if (!canPull || inProgress) return;
		Activate(player);
	}

	public virtual void Activate(GameObject player)
	{
		user = player.gameObject;
		inProgress = true;
	}

	public virtual void Win(Rarity rarity)
    {
		Debug.Log("You won a " + rarity + " item");
		switch (rarity)
		{
			case Rarity.BulletModeWin:
				RewardRef.GiveMeBulletSpread(Random.Range(1, 2));
				break;
			case Rarity.BigBulletModeWin:
				RewardRef.GiveMeBulletSpread(3);
				break;
			case Rarity.BulletTypeWin:
				RewardRef.GiveMeBulletType(Random.Range(1, 4));
				break;
			case Rarity.StatWin:
				StatsManager.attackPower++;
				break;
		}
    }

	public virtual void Loss()
	{
		Debug.Log("You Lost, Try Again");
	}
}
