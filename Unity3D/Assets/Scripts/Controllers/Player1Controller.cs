// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 5f;
    public float mouseSensitivity = 1f; // Adjust this value for sensitivity

    private bool isMouseButtonDown = false;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            HandleTouchControls();
        }
        else
        {
            HandleMouseControls();
        }

        ClampPaddlePosition();
    }

    void HandleMouseControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseButtonDown = true;
            Cursor.visible = false; // Hide the cursor when the button is pressed
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseButtonDown = false;
            Cursor.visible = true; // Show the cursor when the button is released
        }

        if (isMouseButtonDown)
        {
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // Apply sensitivity
            transform.position += new Vector3(0, mouseY, 0) * speed * Time.deltaTime;
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }

    void HandleTouchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is on the left half of the screen
            if (touch.position.x < Screen.width / 2)
            {
                float moveVertical = touch.deltaPosition.y / Screen.height;
                transform.position += new Vector3(0, moveVertical, 0) * speed * Time.deltaTime;
                transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
            }
        }
    }

    void ClampPaddlePosition()
    {
        float minY = -3.6f;
        float maxY = 5.6f;

        float yPos = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}

