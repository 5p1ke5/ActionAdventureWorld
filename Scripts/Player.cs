    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float turningSpeed = 60f;
    public float jumpPower = 5f;

    public Sprite walkSprite;

    bool jump;

    private Rigidbody rigidBody;
    private Camera cam;
    private GameObject sprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.current;
        sprite = transform.GetChild(0).gameObject;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = walkSprite;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);


        jump = CrossPlatformInputManager.GetButton("Jump");

        if (jump)
        {
            if (Physics.Raycast(transform.position, -Vector3.up / 20, 1))
            {
                // ... add force in upwards.
                rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
            else
            {
                //add less force upwards
                rigidBody.AddForce(Vector3.up * (jumpPower / 100), ForceMode.Impulse);
            }

        }
    }
}
