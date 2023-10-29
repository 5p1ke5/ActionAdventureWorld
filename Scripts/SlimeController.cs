using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlimeController : MonoBehaviour
{
    public int hp = 2;
    public float moveSpeed = 2f;
    public float detectRadius = 10f;
    public float gravityValue = -10f;
    public float dragValue = 0.1f;
    public float flickerSeconds = 3;

    private CharacterController controller;
    private GameObject childObject;
    private Animator animator;
    private SpriteRenderer renderer;
    private Transform target;

    private bool grounded;
    private Vector3 velocity;
    private float flicker = 0;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        childObject = transform.GetChild(0).gameObject;
        animator = childObject.GetComponent<Animator>();
        renderer = childObject.GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Player").transform; 
    }

    void Update()
    {
        //If the object is grounded cancels gravity.
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        //Always points sprite at camera.
        childObject.transform.LookAt(Camera.main.transform.position, Vector3.up);

        //If the player is close enough moves towards them.
        float distance = Vector3.Distance(target.position, transform.position);
        
        Vector3 vector = Vector3.zero;
        if (distance <  detectRadius)
        {
            vector = (target.position - transform.position).normalized * moveSpeed * Time.deltaTime;
            controller.Move(vector);
        }

        //Use physics to move character.
        velocity.y += gravityValue * Time.deltaTime;

        //Applies friction
        if (Math.Abs(velocity.x) > dragValue)
        {
            int sign = Math.Sign(velocity.x);
            velocity.x -= dragValue * sign;
        }
        else { velocity.x = 0; }

        if (Math.Abs(velocity.x) > dragValue)
        {
            int sign = Math.Sign(velocity.z);
            velocity.z -= dragValue * sign;
        }
        else { velocity.z = 0; }

        controller.Move(velocity * Time.deltaTime);

        //Animation things
        animator.SetFloat("moveSpeed", vector.magnitude);

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

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "PlayerHurtbox":
                hp--;

                if (hp > 0)
                {
                    Vector3 knockback = (other.transform.position - transform.position).normalized * Time.deltaTime * -500;
                    velocity += knockback;
                    flicker = flickerSeconds * Time.deltaTime;
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
