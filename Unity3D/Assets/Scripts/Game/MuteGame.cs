// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/


using UnityEngine;
using UnityEngine.UI;

public class MuteGame : MonoBehaviour
{
    private bool isMuted = false;
    public Button muteButton; // Reference to your UI button for muting

    void Start()
    {
        // Assign the onClick event to your MuteButtonClick method
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(MuteButtonClick);
        }
    }

    void MuteButtonClick()
    {
        if (isMuted)
        {
            UnmuteGame();
        }
        else
        {
            MuteGameLogic();
        }
    }

    void MuteGameLogic()
    {
        // Implement your logic to mute the game (e.g., set audio volume to 0)
        AudioListener.volume = 0f;
        isMuted = true;
    }

   public void UnmuteGame()
    {
        // Implement your logic to unmute the game (e.g., set audio volume to 1)
        AudioListener.volume = 1f;
        isMuted = false;
    }
}
