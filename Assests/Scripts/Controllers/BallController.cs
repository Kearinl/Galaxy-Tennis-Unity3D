// Galaxy Tennis - Game Script
// Version 0.1.0
// Happy Dayz Games
// 27/05/2024
// https://github.com/Kearinl/

using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public MaterialSwitcher materialSwitcher;
    public AudioClip wallHitSound; // Assign the wall hit sound in the Inspector
    public AudioClip paddleHitSound; // Assign the paddle hit sound in the Inspector
	public AudioClip goalSound; // Add a reference to your goal sound
    [Range(0.0f, 1.0f)] public float soundVolume = 1.0f; // Volume adjustment

    private Vector3 direction;
    private Rigidbody rb;
    private bool isBallActive = true;
    private AudioSource audioSource;
    

    void Awake()
    {
        materialSwitcher = GetComponent<MaterialSwitcher>();
        float angle = Random.Range(60f, 240f);
        Vector3 randomDirection = Quaternion.Euler(0, 0, angle) * Vector3.right;
        randomDirection.y = 0f;
        direction = randomDirection.normalized;

        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.interpolation = RigidbodyInterpolation.Interpolate; // or Extrapolate

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if not already present
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void FixedUpdate()
    {
        if (isBallActive)
        {
            float distance = speed * Time.fixedDeltaTime;
            RaycastHit hit;

            // Perform a physics raycast to check for collisions
            if (Physics.Raycast(transform.position, direction, out hit, distance))
            {
                if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("AIPlayer"))
                {
                    HandleCollision(hit.collider);
                    PlaySoundEffect(paddleHitSound);
                }
                else if (hit.collider.CompareTag("Player1Goal") || hit.collider.CompareTag("AIPlayerGoal"))
                {
                    HandleGoal(hit.collider);
                    PlaySoundEffect(goalSound);
                }
                else if (hit.collider.CompareTag("Wall"))
                {
                    HandleWall(hit.collider);
                    PlaySoundEffect(wallHitSound);
                }
            }

            // Continue with the rest of the FixedUpdate logic
            rb.MovePosition(rb.position + direction * distance);
        }
    }


 void HandleGoal(Collider goalCollider)
    {
        Debug.Log("Goal Scored!");

        if (audioSource != null && goalSound != null)
        {
            audioSource.PlayOneShot(goalSound, soundVolume);
        }

        ResetAndLaunchBall();
    }

 void HandleWall(Collider wallCollider)
    {
        Vector3 wallNormal = wallCollider.ClosestPoint(transform.position) - transform.position;
        float dotProduct = Vector3.Dot(direction, wallNormal.normalized);

        if (dotProduct > 0)
        {
            direction = Vector3.Reflect(direction, wallNormal.normalized);
        }
        else
        {
            direction = Vector3.Reflect(direction, Vector3.Cross(wallNormal.normalized, Vector3.forward));
        }
    }

    void HandleCollision(Collider collider)
    {
        direction = -direction;

        if (collider.CompareTag("Player"))
        {
            float paddleSpeed = collider.GetComponent<Player1Controller>().speed;
            float yDirection = Mathf.Sign(direction.y);
            direction.y += yDirection * paddleSpeed * 0.1f;
            direction = direction.normalized;
        }
        else if (collider.CompareTag("AIPlayer"))
        {
            float paddleSpeed = collider.GetComponent<Player2AI>().speed;
            float yDirection = Mathf.Sign(direction.y);
            direction.y += yDirection * paddleSpeed * 0.1f;
            direction = direction.normalized;
        }
    }

    private Vector3 initialPosition;

    public void ResetAndLaunchBall()
    {
        initialPosition = Vector3.zero;
        rb.velocity = Vector3.zero; // Stop the ball's movement
        transform.position = initialPosition;

        float sideDirection = Random.Range(0, 2) * 2 - 1;
        float yVariation = Random.Range(-0.2f, 0.2f);
        direction = new Vector3(sideDirection, yVariation, 0).normalized;

        materialSwitcher.ToggleMaterial();
        isBallActive = true;
    }

    void PlaySoundEffect(AudioClip soundClip)
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip, soundVolume);
        }
    }
}

