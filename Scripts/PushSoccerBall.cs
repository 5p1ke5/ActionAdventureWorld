using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    public float kickForce = 10f; // Adjust the force as needed
    public float kickRange = 5f; // Adjust the kick range as needed
    private GameObject respawnPoint;
    private SoccerFieldManager soccerFieldManager;

    private void Start()
    {
        // Find the respawn point by tag at the start
        respawnPoint = GameObject.FindGameObjectWithTag("BallSpawn");

        // If the respawn point is not found, use the initial position as a fallback
        if (respawnPoint == null)
        {
            respawnPoint = this.gameObject; // Use the ball itself as a fallback
        }

        // Find the SoccerGameManager in the scene
        soccerFieldManager = FindObjectOfType<SoccerFieldManager>();
    }

    void Update()
    {
        // Check for input, e.g., the Q key, to kick the ball
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryKickBall();
        }
    }

    void TryKickBall()
    {
        // Find the player GameObject (you can customize this based on your setup)
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            // Check the distance between the player and the ball
            float distance = Vector3.Distance(player.transform.position, transform.position);

            // If the player is in range, kick the ball
            if (distance <= kickRange)
            {
                KickBall();
            }
            else
            {
                // Player is out of range, do nothing or provide feedback
                Debug.Log("Out of range to kick the ball!");
            }
        }
    }

    void KickBall()
    {
        // Apply force to the ball using Rigidbody
        Rigidbody ballRb = GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            // Calculate the force direction using the player's position
            Vector3 forceDirection = (transform.position - GameObject.FindWithTag("Player").transform.position).normalized;

            // Apply force to the ball
            ballRb.AddForce(forceDirection * kickForce, ForceMode.Impulse);
        }
    }

    // Check if the ball enters the goal post
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoalPostHome"))
        {
            Debug.Log("Goal! You scored a point for Home!");
          soccerFieldManager.IncrementHomeScore(); // Increment the home score
            RespawnBall();
        }
        else if (other.CompareTag("GoalPostAway"))
        {
            Debug.Log("Goal! You scored a point for Away!");
          soccerFieldManager.IncrementAwayScore(); // Increment the away score
            RespawnBall();
        }
        else if (other.CompareTag("BallGone"))
        {
            RespawnBall();
        }
    }

    private void RespawnBall()
    {
        // Reset the position of the ball to the respawn point
        transform.position = respawnPoint.transform.position;

        // Zero out the velocity to prevent residual motion
        Rigidbody ballRb = GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }
    }
}