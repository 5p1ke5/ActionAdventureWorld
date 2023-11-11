using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    //This is read in the 'Hitbox' script and applied to the physics of the component that collides with it..
    public Vector3 bounceVelocity = new Vector3(0, 15f, 0);

    private GameObject childObject;
    private Animator animator;

    private void Start()
    {
        childObject = transform.GetChild(0).gameObject;
        animator = childObject.GetComponent<Animator>();
    }

    public void Bounce()
    {
        if (animator != null) 
        {
            animator.SetTrigger("Bounce");
        }
    }
}
