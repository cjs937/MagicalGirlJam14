using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public GameObject gameOverScreen;//Prefab;
    //public Canvas canvas;
    //public GameObject gameOverInstance;
    PlayerMovementScript playerMovementScript;
    EnemyManager enemyManager;
    TimerScript timer;
    public TextMeshProUGUI timerText;

    void Start()
    {
        playerMovementScript = FindAnyObjectByType<PlayerMovementScript>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
        timer = FindAnyObjectByType<TimerScript>();
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        playerMovementScript.enabled = false;
        enemyManager.StopAllEnemies();
        timerText.text = "You lasted " + Mathf.Floor(timer.time).ToString() + " seconds! \n" + 
            "Enemy kills: " + enemyManager.killCount;
        timer.enabled = false;
        gameOverScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
