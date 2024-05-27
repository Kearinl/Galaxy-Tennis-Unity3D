// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text winText; // Add a reference to the UI Text for displaying the winner
    public Text setInfoText; // Add a reference to the UI Text for displaying set information

    [SerializeField] private int scoreToWin = 25; // Serialized field to expose in Unity Editor
    [SerializeField] private List<string> scenesToUnlock; // List of scenes to unlock

    private int player1Score = 0;
    private int player2Score = 0;
    private int unlockedSceneIndex = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Display set information at the start of the game
        UpdateSetInfoText();
    }

    // Increment the score based on the player who scored
    public void IncrementScore(string playerTag)
    {
        if (playerTag == "Player")
        {
            player2Score++;
        }
        else if (playerTag == "PlayerAI")
        {
            player1Score++;
        }

        UpdateScoreText();

        // Check for a winner
        CheckForWinner();
    }

    void UpdateScoreText()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    void UpdateSetInfoText()
    {
        setInfoText.text = "First to " + scoreToWin.ToString();
    }

    void CheckForWinner()
{
    if (player1Score >= scoreToWin)
    {
        UnlockNextLevel();
        PauseGame();
        DisplayWinner();
    }
    else if (player2Score >= scoreToWin)
    {
        StartCoroutine(DelayBeforeReloadScene());
        PauseGame();
        DisplayWinner(); // Display the winner for Player 2
    }
}

IEnumerator DelayBeforeReloadScene()
{
    yield return new WaitForSeconds(3f); // Adjust the delay time as needed
    ReloadScene();
}

void DisplayWinner()
{
    if (player1Score >= scoreToWin)
    {
        winText.text = "Player 1 Wins!";
    }
    else if (player2Score >= scoreToWin)
    {
        winText.text = "Player 2 Wins!";
    }
}

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UnlockNextLevel()
    {
        // Add logic here to unlock the next level
        // For example, load the next scene

        if (unlockedSceneIndex < scenesToUnlock.Count)
        {
            string nextSceneName = scenesToUnlock[unlockedSceneIndex];
            SceneManager.LoadScene(nextSceneName);
            unlockedSceneIndex++;
        }
        else
        {
            Debug.LogWarning("No more scenes available.");
        }
    }

    void PauseGame()
    {
        // Implement your pause game logic here
        // For example, you can set Time.timeScale to 0 to pause the game
        Time.timeScale = 0f;
    }

}
