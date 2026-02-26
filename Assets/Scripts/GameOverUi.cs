using UnityEngine;

public class GameOverUi : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Awake()
    {
        if(gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void OnEnable()
    {
        GameManager.OnGameStateChanged += HandleStateChanged;
    }

    void OnDisable()
    {
        GameManager.OnGameStateChanged -= HandleStateChanged;
    }

    void HandleStateChanged(GameManager.GameState state)
    {
        if(gameOverPanel != null)
            gameOverPanel.SetActive(state == GameManager.GameState.GameOver);
    }

    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }

    public void MainMenu()
    {
        GameManager.Instance.GoToMainMenu();
    }
}
