// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    void Update()
    {
        // Get the current rotation of the skybox material
        float currentRotation = RenderSettings.skybox.GetFloat("_Rotation");

        // Update the rotation based on time and speed
        currentRotation += rotationSpeed * Time.deltaTime;

        // Apply the new rotation to the skybox material
        RenderSettings.skybox.SetFloat("_Rotation", currentRotation);
    }
}

