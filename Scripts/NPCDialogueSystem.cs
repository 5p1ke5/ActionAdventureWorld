using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueSystem : MonoBehaviour
{
    // Player Detection value assigned to false
    bool playerDetection = false;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        // If statement so if player is in the detection range and presses F on NPC
        // Then Dialogue print statement in console is shown for now
       if(playerDetection && Input.GetKeyDown(KeyCode.F))
       {
        print("Dialogue Started!");
       } 
    }

    private void OnTriggerEnter(Collider other)
    { 
        // if OnTrigger detects the Player, then Player Detection is set to true
        if(other.name == "Player")
        {
            playerDetection = true;
        }
    }
        private void OnTriggerExit(Collider other)
    {
        // Player Detection is set to false when left range
            playerDetection = false;
    }
}
