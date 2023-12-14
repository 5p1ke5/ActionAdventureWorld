using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatPortal : MonoBehaviour
{
    void Start()
    {
        int crystalsGot = 0;
        foreach (var crystalBool in Globals.crystalsCollected)
        {
            if (crystalBool == true)
            {
                crystalsGot++;
            }
        }

        if (crystalsGot >= 4)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.enabled = true;
        }
    }
}
