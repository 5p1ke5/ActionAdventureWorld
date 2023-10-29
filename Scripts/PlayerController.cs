using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 4.0f; //How fast the player moves.
    public int runMod = 2; //Multiplier to movement speed while run button is held down
    public int jumpMod = 2; //The player's gravity is divided by this while the jump button is held down.
    public float jumpHeight = 1f; //How high you jump
    public float gravityValue = -10f; //How fast the player is pulled down
    public int hp = 3;
    public float flickerSeconds = 3;

    //Components that are initialized in fields.
    public GameObject hurtboxPrefab;

    //Components we'll get during the starting event
    private CharacterController controller;
    private GameObject childObject;
    private Animator animator;
    private SpriteRenderer renderer;

    //private variables governing player movement.
    private Vector3 playerVelocity;
    private bool grounded;
    private float flicker = 0;
    public float dragValue = 0.1f;
    private bool punch = false;

    private void Start()
    {
        //Getting components
        childObject = transform.GetChild(0).gameObject;
        controller = gameObject.GetComponent<CharacterController>();
        animator = childObject.GetComponent<Animator>();
        renderer = childObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ///Physics things.
        //If the controller is grounded sets vertical speed to 0.
        grounded = controller.isGrounded;
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

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
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -1f * gravityValue);
                }
            }
                
            punch = Input.GetButtonDown("Fire1");
            if (punch)
            {
                GameObject newHurtbox = Instantiate(hurtboxPrefab, transform);
                newHurtbox.transform.parent = null;
            }
        }


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


        //Additionally if the jump button is being held down offsets gravity, allowing the player to jump higher by holding the jump button.
        int gravOffset = Input.GetButton("Jump") ? jumpMod : 1;

        playerVelocity.y += (gravityValue / gravOffset) * Time.deltaTime;

        //Applies friction
        if (Math.Abs(playerVelocity.x) > dragValue)
        {
            int sign = Math.Sign(playerVelocity.x);
            playerVelocity.x -= dragValue * sign;
        }
        else { playerVelocity.x = 0; }

        if (Math.Abs(playerVelocity.x) > dragValue)
        {
            int sign = Math.Sign(playerVelocity.z);
            playerVelocity.z -= dragValue * sign;
        }
        else { playerVelocity.z = 0; }

        controller.Move(playerVelocity * Time.deltaTime);


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

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "EnemyHurtbox":
                if (flicker <= 0)
                {
                    hp--;
                    Debug.Log(hp);
                    if (hp > 0)
                    {
                        Vector3 knockback = (other.transform.position - transform.position).normalized * Time.deltaTime * -500;
                        playerVelocity += knockback;
                        flicker = flickerSeconds * Time.deltaTime;
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                }
                break;
            default:
                break;
        }
    }
}
