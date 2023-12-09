using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorNPC : MonoBehaviour
{

    //Makes the door disappear when you talk to the mayor.
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(door);
        }
    }
}
