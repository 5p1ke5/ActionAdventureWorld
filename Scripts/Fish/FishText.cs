using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishText : MonoBehaviour
{
    public GameObject fishLeftGO; //provided via inspector
    const string fishCollectedTextPrefix = "Fish: ";


    public static int fishCollected;
    int fishSpawned;
    private Text fishComp;

    // Start is called before the first frame update
    void Start()
    {



        fishSpawned = GetComponent<FishSpawner>().ReturnFishToSpawn();
        fishComp = fishLeftGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        int fishCollectedCalc = ((fishSpawned - fishCollected) % fishSpawned);

        fishComp.text = fishCollectedTextPrefix + fishCollectedCalc + "/" + fishSpawned;

    }
}
