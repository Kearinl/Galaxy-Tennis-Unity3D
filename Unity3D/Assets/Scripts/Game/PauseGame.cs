// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/


using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public Button pauseButton; // Reference to your UI button

    void Start()
    {
        // Assign the onClick event to your PauseButtonClick method
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(PauseButtonClick);
        }
    }

    void PauseButtonClick()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGameLogic();
        }
    }

    void PauseGameLogic()
    {
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Set the time scale back to 1 to unpause the game
        isPaused = false;
    }
}
