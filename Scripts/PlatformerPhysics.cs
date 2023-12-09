using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPhysics : MonoBehaviour
{
    //Public parameters.
    public float gravityValue = -10f; //How fast the object is pulled downwards
    public float dragValue = 0.1f; //Friction

    //Components we'll get during the starting event
    private CharacterController controller;

    //Other private variables.
    private bool grounded;
    public Vector3 velocity;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        //If the object is grounded cancels gravity.
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        //Applies gravity.
        velocity.y += gravityValue * Time.deltaTime;

        //Applies drag
        if (Math.Abs(velocity.x) > dragValue)
        {
            int sign = Math.Sign(velocity.x);
            velocity.x -= dragValue * sign;
        }
        else { velocity.x = 0; }

        if (Math.Abs(velocity.z) > dragValue)
        {
            int sign = Math.Sign(velocity.z);
            velocity.z -= dragValue * sign;
        }
        else { velocity.z = 0; }

        controller.Move(velocity * Time.deltaTime);
    }
}
