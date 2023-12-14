using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreatPortal : MonoBehaviour
{
    private bool open = false;
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
            open = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (open)
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }
}
