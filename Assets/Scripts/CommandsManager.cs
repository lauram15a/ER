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
                QuitGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TogglePause();
            }
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
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
        Debug.Log("Game paused...");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; 
        pauseScreen.SetActive(false);
        Debug.Log("Game resumed...");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
