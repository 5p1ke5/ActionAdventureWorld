using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public float playerSpeed = 4.0f; //How fast the player moves.
    private int runMod = 2; //Multiplier to movement speed while run button is held down
    private int jumpMod = 2; //The player's gravity is divided by this while the jump button is held down.
    public float jumpHeight = 1f; //How high you jump
    public float gravityValue = -10f; //How fast the player is pulled down

    //Components that are initialized in fields.
    public GameObject hurtbox;

    //Components we'll get during the starting event
    private CharacterController controller;
    private Animator animator;

    //privte physics variables.
    private Vector3 playerVelocity;
    private bool grounded;

    private void Start()
    {
        //Getting components
        controller = gameObject.GetComponent<CharacterController>();
        animator = transform.GetChild(0).GetComponent<Animator>();
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

        //Attack
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newHurtbox = Instantiate(hurtbox, transform);
            newHurtbox.transform.parent = null;

        }

        //Additionally if the jump button is being held down offsets gravity, allowing the player to jump higher by holding the jump button.
        int gravOffset = Input.GetButton("Jump") ? jumpMod : 1;

        playerVelocity.y += (gravityValue / gravOffset) * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        ///Animation things
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetBool("grounded", grounded);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "EnemyHurtbox":
                Debug.Log("Enemy got you!");
                break;
            default:
                break;
        }
    }
}
