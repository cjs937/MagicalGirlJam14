using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public GameObject gameOverScreen;//Prefab;
    //public Canvas canvas;
    //public GameObject gameOverInstance;
    PlayerMovementScript playerMovementScript;
    EnemyManager enemyManager;
    void Start()
    {
        playerMovementScript = FindAnyObjectByType<PlayerMovementScript>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        playerMovementScript.enabled = false;
        enemyManager.StopAllEnemies();

        //gameOverInstance = Instantiate(gameOverScreenPrefab);
        //gameOverInstance.transform.parent = canvas.transform;
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
