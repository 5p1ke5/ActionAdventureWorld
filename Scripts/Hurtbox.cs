using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes the hurtbox destroy itself very shortly after spawning.
public class Hurtbox : MonoBehaviour
{
    public float duration = 3.1f;
    void Start()
    {
        duration = duration * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            Destroy(gameObject);
        }
    }
}
