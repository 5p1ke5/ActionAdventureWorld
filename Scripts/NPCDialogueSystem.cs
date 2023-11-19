using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class NPCDialogueSystem : MonoBehaviour
{
    //Time to wait between displaying the texts in the array.
    public float textTimeIncrement = 5.0f;

    //Different messages for the NPC to display. One message is ideal but you can do more if necessary.
    public string[] texts;

    //Text component that will display texts. Will usually be set in prefab.
    public Text dialogueText;

    // Player Detection value assigned to false
    bool playerDetection = false;

    //Timer variable.
    private float textTimer;
    private int textIndex = 0;

    void Start()
    {
        dialogueText.gameObject.SetActive(false);
        textTimer = textTimeIncrement;
    }
    
    void Update()
    {
        if (playerDetection)
       {
            dialogueText.text = texts[textIndex];

            //Increment timer.
            if (textTimer > 0)
            {
                textTimer -= Time.deltaTime;
            }
            //If timer finishes counting down increments index, resets timer.
            else
            {
                textIndex++;
                if (textIndex >= texts.Length)
                {
                    //If index reaches the end of the texts array resets it to 0.
                    textIndex = 0;
                }

                textTimer = textTimeIncrement;
            }
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
