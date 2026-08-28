using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject gameOverScreenPrefab;
    public Canvas canvas;
    public GameObject gameOverInstance;
    PlayerMovementScript playerMovementScript;

    void Start()
    {
        playerMovementScript = FindAnyObjectByType<PlayerMovementScript>();
    }

    public void GameOver()
    {
        playerMovementScript.enabled = false;
        
        gameOverInstance = Instantiate(gameOverScreenPrefab);
        gameOverInstance.transform.parent = canvas.transform;
    }
}
