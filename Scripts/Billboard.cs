using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Sprite is always pointed at the camera.
public class Billboard : MonoBehaviour
{
    void Update()
    {
 
            transform.LookAt(Camera.main.transform.position, Vector3.up);
        
     
    }
}
