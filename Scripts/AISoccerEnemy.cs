using System.Collections;
using UnityEngine;

public class AISoccerEnemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float pushForce = 2f;
    public float stoppingDistance = 2f;
    public Transform aiRespawnPoint;
    public float returnToRespawnInterval = 3f; // Adjust this as needed

    private SoccerFieldManager soccerFieldManager;
    private bool isReturningToRespawn = false;

    void Start()
    {
        soccerFieldManager = FindObjectOfType<SoccerFieldManager>();

        if (soccerFieldManager == null)
        {
            Debug.LogError("SoccerFieldManager not found!");
        }

        // Set the initial position to the respawn point
        RespawnAtAIRespawnPoint();
    }

    void Update()
    {
        // Check if the player is in the field
        if (soccerFieldManager.IsPlayerInField())
        {
            // Move towards the ball
            MoveTowardsBall();
            isReturningToRespawn = false; // Reset the flag if the player is in the field
        }
        else if (!isReturningToRespawn)
        {
            // If the player is not in the field, start returning to respawn point
            StartCoroutine(ReturnToRespawnPoint());
        }
    }

    IEnumerator ReturnToRespawnPoint()
    {
        isReturningToRespawn = true;

        // Wait for a short interval before returning to respawn point
        yield return new WaitForSeconds(returnToRespawnInterval);

        // Return to respawn point
        RespawnAtAIRespawnPoint();
    }

    void MoveTowardsBall()
    {
        GameObject soccerBall = GameObject.FindGameObjectWithTag("SoccerBall");

        if (soccerBall != null)
        {
            Vector3 directionToBall = soccerBall.transform.position - transform.position;
            directionToBall.y = 0f;

            transform.Translate(directionToBall.normalized * moveSpeed * Time.deltaTime);

            float distanceToBall = directionToBall.magnitude;

            if (distanceToBall <= stoppingDistance)
            {
                ApplyPushForce(soccerBall);
            }
        }
    }

    void ApplyPushForce(GameObject soccerBall)
    {
        GameObject awayGoal = GameObject.FindGameObjectWithTag("GoalPostHome");

        if (soccerBall != null && awayGoal != null)
        {
            Vector3 forceDirection = (awayGoal.transform.position - soccerBall.transform.position).normalized;

            Rigidbody ballRb = soccerBall.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.AddForce(forceDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

    // Call this method when the cube scores
    public void RespawnAfterScore()
    {
        RespawnAtAIRespawnPoint();
    }

    private void RespawnAtAIRespawnPoint()
    {
        if (aiRespawnPoint != null)
        {
            transform.position = aiRespawnPoint.position;
        }
    }
}