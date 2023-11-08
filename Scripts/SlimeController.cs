using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public int hp = 2; 
    public float moveSpeed = 2f;
    public float detectRadius = 10f;
    public float flickerSeconds = 3;

    private CharacterController controller;
    private GameObject childObject;
    private Animator animator;
    private SpriteRenderer renderer;
    private Transform target;
    private AudioSource audioSource;
    private PlatformerPhysics physics;

    private float flicker = 0;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        childObject = transform.GetChild(0).gameObject;
        animator = childObject.GetComponent<Animator>();
        renderer = childObject.GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Player").transform;
        audioSource = gameObject.GetComponent<AudioSource>();
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

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //If it collides with a hurtbox made by the player takes damage and maybe destroys self.
            case "PlayerHurtbox":
                if (flicker <= 0)
                {
                    hp--;
                    audioSource.PlayOneShot(audioSource.clip);

                    if (hp > 0)
                    {
                        Vector3 knockback = (other.transform.position - transform.position).normalized * Time.deltaTime * -500;
                        physics.velocity += knockback;
                        flicker = flickerSeconds * Time.deltaTime;
                    }
                    else
                    {
                        Destroy(gameObject);
                        int slimes = GameObject.FindGameObjectsWithTag("Enemy").Length;
                        if (slimes == 1)
                        {
                            SceneManager.LoadScene("WinMenu");
                            Cursor.lockState = CursorLockMode.None;
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
}
