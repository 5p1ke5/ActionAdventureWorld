using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueSystem : MonoBehaviour
{
    public string text = "Hello traveller!";

    public Text dialogueText;
    // Player Detection value assigned to false
    bool playerDetection = false;

    void Start()
    {
        dialogueText.gameObject.SetActive(false);
    }
    
    void Update()
    {
        // If statement so if player is in the detection range and presses F on NPC
        // Then Dialogue print statement in console is shown for now
       if(playerDetection)
       {
            dialogueText.text = text;
       } 
       else 
       {
            dialogueText.text = "";
       }
    }

    private void OnTriggerEnter(Collider other)
    { 
        // if OnTrigger detects the Player, then Player Detection is set to true
        if(other.tag == "Player")
        {
            playerDetection = true;
            dialogueText.gameObject.SetActive(true);
        }
    }
        private void OnTriggerExit(Collider other)
    {
        // Player Detection is set to false when left range
            playerDetection = false;
            dialogueText.gameObject.SetActive(false);
    }
}
