// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/


using UnityEngine;
using UnityEngine.UI;

public class LevelCountdown : MonoBehaviour
{
    public float countdownDuration = 10f; // Adjust the duration of the countdown
    public Text countdownText; // Reference to a UI Text component to display the countdown

    private float currentCountdown;

    void Start()
    {
        // Initialize the countdown
        currentCountdown = countdownDuration;

        // Pause the game at the start
        Time.timeScale = 0f;

        // Display initial countdown
        UpdateCountdownText();
    }

    void Update()
    {
        // Update the countdown timer
        currentCountdown -= Time.unscaledDeltaTime;

        // Update the UI text
        UpdateCountdownText();

        // Check if the countdown has reached zero
        if (currentCountdown <= 0f)
        {
            // Unpause the game and start gameplay
            Time.timeScale = 1f;
            
            // Disable the countdown UI text
            if (countdownText != null)
            {
                countdownText.gameObject.SetActive(false);
            }

            // You can add any additional initialization or start logic here

            // Disable this script to prevent further updates
            enabled = false;
        }
    }

    void UpdateCountdownText()
    {
        // Display the countdown on the UI text
        if (countdownText != null)
        {
            countdownText.text = Mathf.Ceil(currentCountdown).ToString();
        }
    }
}
