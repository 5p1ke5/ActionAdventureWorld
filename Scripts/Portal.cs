using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
   // public GameObject fpsController;
    public System.String sceneToChangeTo;
  

   

    void Start()
    {
         
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToChangeTo);
           // SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToChangeTo));
        }
    }

    //void MoveTo(GameObject player, Vector3 position)
    //{
    //    CharacterController controllerScript = player.GetComponent<CharacterController>();
    //    controllerScript.enabled = false;
    //    player.transform.position = position;
    //    controllerScript.enabled = true;
    //}
}
