using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogSystemScript : MonoBehaviour
{

    public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sc.radius = 6;
    }


    //in like a game controller script say if tag == "npc" then check if it hits the collider
}
