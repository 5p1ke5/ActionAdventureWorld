using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectRadius = 10f;
    public float gravityValue = -10f;
    public float dragValue = 0.1f;

    private CharacterController controller;
    private Animator animator;
    private GameObject childRenderer;
    private Transform target;

    private bool grounded;
    private Vector3 velocity;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        childRenderer = transform.GetChild(0).gameObject;
        animator = childRenderer.GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform; 
    }

    void Update()
    {
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        childRenderer.transform.LookAt(Camera.main.transform.position, Vector3.up);

        float distance = Vector3.Distance(target.position, transform.position);
        
        Vector3 vector = Vector3.zero;
        if (distance <  detectRadius)
        {
            vector = (target.position - transform.position).normalized * moveSpeed * Time.deltaTime;
            controller.Move(vector);
        }


        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        animator.SetFloat("moveSpeed", vector.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "PlayerHurtbox":
                Vector3 knockback = (other.transform.position - transform.position).normalized * 5000 * Time.deltaTime;
                Debug.Log("Enemy hit!" + knockback.ToString());
                velocity += knockback * Time.deltaTime;
                break;
            default:
                break;
        }
    }
}
