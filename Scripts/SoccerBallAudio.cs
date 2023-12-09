using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerAudio : MonoBehaviour
{
    public AudioClip kickSound; // Reference to your kicking sound
    public float kickRange = 5f; // Adjust the kick range as needed

    private AudioSource audioSource;
    private GameObject player;

    void Start()
    {
        // Get the AudioSource component from the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the audio clip
        audioSource.clip = kickSound;

        // Find the player reference
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Check for input,which is the Q key, to play the kick sound
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryKickBall();
        }
    }

    void TryKickBall()
    {
        if (player != null)
        {
            // Check the distance between the player and the ball
            float distance = Vector3.Distance(player.transform.position, transform.position);

            // If the player is in range, play the kick sound
            if (distance <= kickRange)
            {
                PlayKickSound();
            }
        }
    }

    void PlayKickSound()
    {
        // Play the kick sound
        audioSource.Play();
    }
}