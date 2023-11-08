using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 4.0f; //How fast the player moves.
    public int runMod = 2; //Multiplier to movement speed while run button is held down
    public float gravOffset = 0.04f; //Offsets gravity while falling, letting the player jump higher while the jump button is held.
    public float jumpHeight = 1f; //How high you jump
    public int hp = 3; //How much HP you have.
    public float flickerSeconds = 3; //How long invulnerability flicker lasts.

    //Components that are initialized in fields.
    public GameObject hurtboxPrefab;
    public TextMeshProUGUI lifeScore;

    //Components we'll get during the starting event
    private CharacterController controller;
    private GameObject childObject;
    private Animator animator;
    private SpriteRenderer renderer;
    private AudioSource audioSource;
    private PlatformerPhysics physics;

    //private variables governing player movement.
    //private Vector3 velocity; //vector used to control movement by outside forces.
    private bool grounded;
    private float flicker = 0;
    private bool punch = false;

    private void Start()
    {
        //Getting components
        childObject = transform.GetChild(0).gameObject;
        controller = gameObject.GetComponent<CharacterController>();
        animator = childObject.GetComponent<Animator>();
        renderer = childObject.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        physics = gameObject.GetComponent<PlatformerPhysics>();

        lifeScore.text = "Life: " + hp;
    }

    void Update()
    {
        ///Physics things.
        //If the controller is grounded sets vertical speed to 0.
        grounded = controller.isGrounded;

        //Being in an attacking state locks you out of some stuff.
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        {
            //If the run button is held down multiplies movement speed by run mod.
            int running = Input.GetButton("Fire3") ? runMod : 1;

            //Gets vertical and horizontal controller axes and multiplies them by the transforms axes to get two vectors, then uses those vectors to move the object.
            Vector3 vertical = transform.forward * Input.GetAxis("Vertical") * playerSpeed * running * Time.deltaTime;
            Vector3 horizontal = transform.right * Input.GetAxis("Horizontal") * playerSpeed * running * Time.deltaTime;
            Vector3 vector = vertical + horizontal;

            controller.Move(vector);

            //Initial button press makes the player jump if they're grounded (can add in a double jump or something later)
            if (Input.GetButtonDown("Jump"))
            {
                if (grounded)
                {
                    physics.velocity.y = Mathf.Sqrt(jumpHeight * -1f * physics.gravityValue);
                }
            }
                
            //Punches, creates a hurtbox and positions it.
            punch = Input.GetButtonDown("Fire1");
            if (punch)
            {
                GameObject newHurtbox = Instantiate(hurtboxPrefab, transform);
                newHurtbox.transform.parent = null;
            }
        }


        //If the jump button is being held down offsets gravity, allowing the player to jump higher by holding the jump button.
        if (Input.GetButton("Jump"))
        {
            physics.velocity.y += gravOffset;
        }

        ///Animation things
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

        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetBool("grounded", grounded);
        animator.SetBool("punch", punch);
        
    }

    private void OnTriggerStay (Collider other)
    {
        //Different collision types are handled here.
        switch (other.gameObject.tag)
        {
            case "EnemyHurtbox":
                if (flicker <= 0) //Cant take damage if flickering.
                {
                    audioSource.PlayOneShot(audioSource.clip);
                    hp--;
                    lifeScore.text = "Life: " + hp;

                    //Take damage
                    if (hp > 0)
                    {
                        //Gets vector to use to knock the player back and then adds that to velocity to make them knock back during Update.
                        Vector3 knockback = (other.transform.position - transform.position).normalized * Time.deltaTime * -500;
                        physics.velocity += knockback;
                        flicker = flickerSeconds * Time.deltaTime;
                    }
                    else //If HP < 0 kills you and you lose the game.
                    {
                        Cursor.lockState = CursorLockMode.None;
                        SceneManager.LoadScene("LoseMenu");
                    }
                }
                break;
            default:
                break;
        }
    }
}
