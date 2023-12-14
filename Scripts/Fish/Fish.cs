using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public static int fishInScene = 0;
    int fishCollected;
    // Start is called before the first frame update
    void Start()
    {
        Fish.fishInScene++;
        fishCollected = Fish.fishInScene;
        FishText.fishCollected = fishCollected;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fish.fishInScene--;

            Destroy(gameObject, 0.5f);


            fishCollected = Fish.fishInScene;
            FishText.fishCollected = fishCollected;

            if (Fish.fishInScene <= 0)
            {
                Debug.Log("Winner!!");

            }
        }
    }



}
