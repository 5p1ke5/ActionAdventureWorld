using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwayScore : MonoBehaviour
{
    public AudioClip goalAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        // Ensure an AudioSource component is present
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the SoccerBall tag
        if (other.CompareTag("SoccerBall"))
        {
            // Check if the triggering object has the GoalPostAway tag
            if (gameObject.CompareTag("GoalPostAway"))
            {
                PlaySound();
            }
        }
    }

    void PlaySound()
    {
        // Play the goal audio clip
        if (goalAudioClip != null && audioSource != null)
        {
            audioSource.clip = goalAudioClip;
            audioSource.Play();
        }
    }
}