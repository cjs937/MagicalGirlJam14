using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool paused;
    public static PauseScript pauseScript;

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
	}

	public void Resume()
    {
        paused = false;
		foreach (Transform child in transform)
			child.gameObject.SetActive(false);
        Time.timeScale = 1;
	}
}
