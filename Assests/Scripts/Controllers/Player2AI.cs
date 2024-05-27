// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/


using UnityEngine;

public class Player2AI : MonoBehaviour
{
    public Transform ball;
    public float speed = 6f;
    
    // Adjust this speed to control the rotation speed
    public float rotationSpeed = 5f;

    void Update()
    {
        // Simple AI to move towards the predicted position where the ball will land
        float predictedY = PredictBallPosition();
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, predictedY, transform.position.z), step);
        // Rotate the object around the -Z axis in the opposite direction
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        ClampPaddlePosition();
    }

    float PredictBallPosition()
    {
        // Predict the Y position where the ball will land
        float timeToReach = Mathf.Abs((transform.position.y - ball.position.y) / speed);
        float predictedY = ball.position.y + ball.GetComponent<Rigidbody>().velocity.y * timeToReach;

        // Clamp the predicted Y position to stay within the play area
        float minY = -3.6f; // Adjust this value to set the lower limit
        float maxY = 5.6f;  // Adjust this value to set the higher limit
        predictedY = Mathf.Clamp(predictedY, minY, maxY);

        return predictedY;
    }

    void ClampPaddlePosition()
    {
        // Adjust the clamp range
        float minY = -3.6f; // Adjust this value to set the lower limit
        float maxY = 5.6f;  // Adjust this value to set the higher limit

        // Clamp the paddle's Y position to keep it within the play area
        float yPos = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}

