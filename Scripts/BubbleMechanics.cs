using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMechanics : MonoBehaviour
{
    public GameObject player;
    public float bubblespeed;

    private PlatformerPhysics physics;
    private bool goingup = true;
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            float currentX = player.transform.position.x;
            float currentY = player.transform.position.y;
            float currentZ = player.transform.position.z;

            physics = player.GetComponent<PlatformerPhysics>();
            //other.transform.Translate((Vector3.up * Time.deltaTime), Space.World);

            //player.transform.position = new Vector3(currentX, currentY + bubblespeed, currentZ);

            //player.transform.Translate(Vector3.up * Time.deltaTime * bubblespeed *10, Space.World);

            physics.velocity.y += bubblespeed; 

            Debug.Log(player.transform.position);

        }
    }

    //private void OnCollisionExit(Collision collision)
    //{

    //}

 
}
