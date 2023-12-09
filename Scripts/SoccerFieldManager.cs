using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoccerFieldManager : MonoBehaviour
{
    public Text HomeScoreText;
    public Text AwayScoreText;

    private int homeScore = 0;
    private int awayScore = 0;

    bool FieldDetect = false;

    private void Start()
    {
        // Disable the Canvas Text at the start
        HomeScoreText.enabled = false;
        AwayScoreText.enabled = false;
    }

    void Update()
    {
        if (FieldDetect)
        {
            // Update the Canvas Text visibility based on player's location
            HomeScoreText.enabled = true;
            AwayScoreText.enabled = true;
        }
        else
        {
            // Player is outside the detection area, disable the Canvas Text
            HomeScoreText.enabled = false;
            AwayScoreText.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if OnTrigger detects the Player, then Player Detection is set to true
        if (other.CompareTag("Player"))
        {
            FieldDetect = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Player Detection is set to false when left range
        if (other.CompareTag("Player"))
        {
            FieldDetect = false;
        }
    }

    // Method to increment the home score
    public void IncrementHomeScore()
    {
        homeScore++;
        UpdateScoreText();
        CheckForWin();
    }

    // Method to increment the away score
    public void IncrementAwayScore()
    {
        awayScore++;
        UpdateScoreText();
        CheckForWin();
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        HomeScoreText.text = "Home: " + homeScore;
        AwayScoreText.text = "Away: " + awayScore;
    }

    // checkforwin can be used so player hits certain score and crystal spawns
        private void CheckForWin()
    {
        int winningScore = 5; // winning score

        if (homeScore >= winningScore)
        {
            Debug.Log("Home team wins!");
            // Display any additional win-related actions or messages
        }
        else if (awayScore >= winningScore)
        {
            Debug.Log("Away team wins!");
            // Display any additional win-related actions or messages
        }
    }
}