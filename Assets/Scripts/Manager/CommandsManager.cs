using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandsManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    private bool isGamePaused = false;

    void Update()
    {
        if (GameManager.IsGameOver())
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                RestartGame();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            if (GameManager.IsStarted())
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    TogglePause();
                }
            }
        }
    }

    private void RestartGame()
    {
        GameManager.GetGameOverScreen().SetActive(false);
        GameManager.GetUIScreen().SetActive(false);
        GameManager.SetIsGameOver(false);
        GameManager.SetIsStarted(false);
        SceneManager.LoadScene(1);
    }

    private void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; 
        pauseScreen.SetActive(false);
    }
}
