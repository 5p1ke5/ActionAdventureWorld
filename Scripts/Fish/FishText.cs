using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishText : MonoBehaviour
{
    public GameObject fishLeftGO; //provided via inspector
    public GameObject crystal;
    const string fishCollectedTextPrefix = "Fish: ";


    public static int fishCollected;
    int fishSpawned;
    private Text fishComp;
    private bool allfishcollected = false;
   

    // Start is called before the first frame update
    void Start()
    {



        fishSpawned = GetComponent<FishSpawner>().ReturnFishToSpawn();
        fishComp = fishLeftGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        int fishCollectedCalc = (fishSpawned - fishCollected);

        if(fishCollectedCalc == fishSpawned)
        {
            fishCollectedCalc = 0;
        }else if(fishCollected == 0)
        {
            fishCollectedCalc = fishSpawned;
        }

     
        fishComp.text = fishCollectedTextPrefix + fishCollectedCalc + "/" + fishSpawned;




        if(fishCollectedCalc == fishSpawned)
        {
            allfishcollected = true;
        }

        if (allfishcollected)
        {
            crystal.SetActive(true);
            allfishcollected = false;
        }
    }
}
