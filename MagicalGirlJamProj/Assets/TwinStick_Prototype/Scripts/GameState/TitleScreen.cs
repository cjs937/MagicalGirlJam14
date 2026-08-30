using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject creditsScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creditsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("BasicScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleCredits(bool toggle)
    {
        creditsScreen.SetActive(toggle);
    }
}
