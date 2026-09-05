using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour
{
    public static bool paused;
    public static PauseScript pauseScript;

	[SerializeField] Image img;

	void Start()
    {
        pauseScript = this;
	}

	public void Pause()
    {
        paused = true;
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
        Time.timeScale = 0;

        img.enabled = true;
        EventSystem.current.SetSelectedGameObject(transform.GetChild(0).gameObject);
	}

	public void Resume()
    {
        paused = false;
		foreach (Transform child in transform)
			child.gameObject.SetActive(false);

		img.enabled = false;
		Time.timeScale = 1;
	}
}
