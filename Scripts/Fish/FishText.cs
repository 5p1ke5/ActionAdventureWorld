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


        int fishCollectedCalc;
       
        if (fishCollected == 0)
        {
            fishCollectedCalc = 0;
        }else if(fishCollected == fishSpawned)
        {
            
            fishCollectedCalc = fishSpawned;
        }
        else
        {
            fishCollectedCalc = (fishSpawned - fishCollected);
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
