// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float maxRotationSpeed = 30f; // Maximum rotation speed in degrees per second

    void Update()
    {
        // Generate random rotation values for each axis
        float randomRotationX = Random.Range(0f, 360f);
        float randomRotationY = Random.Range(0f, 360f);
        float randomRotationZ = Random.Range(0f, 360f);

        // Calculate the rotation amount based on the maximum rotation speed
        float rotationAmountX = randomRotationX * maxRotationSpeed * Time.deltaTime;
        float rotationAmountY = randomRotationY * maxRotationSpeed * Time.deltaTime;
        float rotationAmountZ = randomRotationZ * maxRotationSpeed * Time.deltaTime;

        // Apply the rotation to the GameObject
        transform.Rotate(rotationAmountX, rotationAmountY, rotationAmountZ);
    }
}

