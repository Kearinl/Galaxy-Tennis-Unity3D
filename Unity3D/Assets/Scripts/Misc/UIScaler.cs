// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    // Set your reference resolution (the resolution you designed your UI for)
    public Vector2 referenceResolution = new Vector2(1920, 1080);

    void Start()
    {
        // Call the ScaleUI method in the Start to scale UI initially
        ScaleUI();
    }

    void ScaleUI()
    {
        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

        if (canvasScaler != null)
        {
            // Calculate the scale factor based on the current screen resolution
            float scaleFactorX = Screen.width / referenceResolution.x;
            float scaleFactorY = Screen.height / referenceResolution.y;

            // Apply the scale factor to the Canvas Scaler
            canvasScaler.scaleFactor = Mathf.Min(scaleFactorX, scaleFactorY);
        }
        else
        {
            Debug.LogWarning("Canvas Scaler component not found on the GameObject. Make sure to attach this script to a GameObject with a Canvas Scaler.");
        }
    }

    // Call this method whenever the screen resolution changes (e.g., in response to a resolution change event)
    public void UpdateUI()
    {
        ScaleUI();
    }
}

