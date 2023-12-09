using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Hitbox : MonoBehaviour
{
    public int hp;
    public float flickerSeconds = 3;

    public float flicker = 0;

    private SpriteRenderer renderer;

    public void Start()
    {
        renderer = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Fickers after taking damage
        if (flicker > 0)
        {
            flicker -= Time.deltaTime;

            if (flicker > 0)
            {
                renderer.enabled = !renderer.enabled;
            }
            else //Always reset renderer at the end of the flicker duration.
            {
                renderer.enabled = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bounce");
        switch (other.gameObject.tag)
        {
            case "Spring":
                PlatformerPhysics platformerPhysics = gameObject.GetComponent<PlatformerPhysics>();
                Spring spring = other.gameObject.GetComponent<Spring>();
                if (spring == null) 
                {
                    break;
                }

                spring.Bounce(); //Makes the spring animate
                if (platformerPhysics)
                {
                    platformerPhysics.velocity = spring.bounceVelocity;
                }
                break;
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();
        if (!rb || rb.isKinematic)
        {
            return;
        }


        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rb.velocity = pushDir * 2/rb.mass;
    }
}
