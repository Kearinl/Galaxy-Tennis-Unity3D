// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load
    public MuteGame muteGame; // Reference to your MuteGame script (optional, remove if not needed)

    public Button resetButton; // Reference to your UI button for resetting the game

    void Start()
    {
        // Assign the onClick event to your ResetButtonClick method
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetButtonClick);
        }
    }

    void ResetButtonClick()
    {
        // Additional reset logic (e.g., unmute the game)
        if (muteGame != null)
        {
            muteGame.UnmuteGame();
        }

        // Load the specified scene
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("SceneToLoad is not assigned. Please assign it in the Unity Editor.");
        }
    }
}

