using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys the forcefield blocking he crystal, changes the mayors dialogue on death.
public class BoxerBoss : MonoBehaviour
{
    public GameObject crystalForcefield;
    public NPCDialogueSystem mayorDialogue;
    private void OnDestroy()
    {
        Destroy(crystalForcefield);

        string[] newTexts = { "PLEASE DON'T HURT ME! YOU CAN TAKE THE CRYSTAL JUST DON'T KILL ME PLEASE!" };
        mayorDialogue.texts = newTexts; 

    }
}
