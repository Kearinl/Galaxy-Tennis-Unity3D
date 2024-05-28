// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    // Define which player's goal this script is attached to
    public string playerTag = "Player"; // Set this to "Player" or "AIPlayer" in the Unity Editor

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            #pragma warning disable
            // Reset and launch the ball when it enters a goal
            BallController ballController = FindObjectOfType<BallController>();
            #pragma warning restore
            if (ballController != null)
            {
                ballController.ResetAndLaunchBall();

                // Notify the ScoreManager about the scoring player
                ScoreManager.instance.IncrementScore(playerTag);
            }
            else
            {
                Debug.LogError("BallController not found in the scene.");
            }
        }
    }
}
