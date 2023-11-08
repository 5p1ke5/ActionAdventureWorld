using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectRadius = 10f;

    private CharacterController controller;
    private GameObject childObject;
    private Animator animator;
    private Transform target;
    private PlatformerPhysics physics;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        childObject = transform.GetChild(0).gameObject;
        animator = childObject.GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        physics = gameObject.GetComponent<PlatformerPhysics>();
    }

    void Update()
    {
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
        //Animation things
        animator.SetFloat("moveSpeed", vector.magnitude);
    }
}
