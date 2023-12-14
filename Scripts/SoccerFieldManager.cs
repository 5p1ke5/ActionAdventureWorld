using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoccerFieldManager : MonoBehaviour
{
    public Text HomeScoreText;
    public Text AwayScoreText;
    public GameObject magicCrystal;

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
            // Reset scores when the player leaves the field
            ResetScores();
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

    // Method to reset scores
    private void ResetScores()
    {
        homeScore = 0;
        awayScore = 0;
        UpdateScoreText();
    }

    // Method to check if the player is in the field
    public bool IsPlayerInField()
    {
        return FieldDetect;
    }

    // Method to check for win
    private void CheckForWin()
    {
        int winningScore = 5; // winning score

        if (homeScore >= winningScore)
        {
            ResetScores();
            // Display any additional win-related actions or messages
        }
        else if (awayScore >= winningScore)
        {
            // Display any additional win-related actions or messages
            EnableMagicCrystal();
        }
    }
private void EnableMagicCrystal()
{
    if (magicCrystal != null)
    {
        magicCrystal.SetActive(true);
    }
}
}