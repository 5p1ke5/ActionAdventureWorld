using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicCrystal : MonoBehaviour
{
    public int rotationSpeed = 100;

    //The currently captured crystals are collected in an array in the Globals class. Pick a number for your crystal that's the one that gets set to true in the array in globals.
    public int crystalIndex = 0;

    //countDownTime is increment, countDownTimer is the actual timer and starts in 'off' state (negative)
    public float countDownTimerIncrement = 3f;
    private float countDownTimer = -1;

    //Mesh renderer from child object.
    private MeshRenderer meshRenderer;
    void Start()
    {
        //Get component from child.
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);

        if (countDownTimer >= 0)
        {
            countDownTimer -= Time.deltaTime;
            if (countDownTimer < 0)
            {
                Die();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCountdown();
        }
    }

    //Starts countdown to return player to the starting area.
    private void StartCountdown()
    {
        meshRenderer.enabled = false;
        countDownTimer = countDownTimerIncrement;
    }

    private void Die()
    {
        Globals.crystalsCollected[crystalIndex] = true;
        foreach (var crystal in Globals.crystalsCollected)
        {
            Debug.Log(crystal);
        }
        SceneManager.LoadScene("Game");
    }
}
