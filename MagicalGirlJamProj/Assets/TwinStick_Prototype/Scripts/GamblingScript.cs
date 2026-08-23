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

	//Player Scripts
	public GameObject user;

	public enum Rarity { none, common, uncommon, rare, epic, legendary};

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
    }

	public virtual void Loss()
	{
		Debug.Log("You Lost, Try Again");
	}
}
