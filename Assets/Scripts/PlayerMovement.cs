using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 3f;
    float normalSpeed = 3f;
    public float gravity = -1.6f;

    // sphere that checks if the player is on the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    public float jumpAcceleration = 4f;
    public bool isJumping = false;

    // IN PROGRESS - starting spherical position
    public float startLat = 0f;
    public float startLong = 0f;
    
    // starting cartesian position
    // public Vector3 startingPosition = new Vector3(19016.856f, -1013.409f, 13417.899f);
    public Vector3 startingPosition = new Vector3(13411.56194f, -1014.30895f, 19008.04084f);

    //Access the CamSwitch Script as An Object ---  NEW SECTION
    public CamSwitch c;

    // Start is called before the first frame update
    void Start()
    {
        // sets starting position
        //transform.position = new Vector3(19016.856f, -1013.409f, 13417.899f);
        transform.position = startingPosition;
        speed = 3f;

        //Saying that our script object c is a going to be a object script reference of the CamSwitch Script --- NEW ADDITION
        c = (CamSwitch)FindObjectOfType(typeof(CamSwitch));
    }

    // Update is called once per frame
    void Update()
    {
        //If the camMode Attribute is 1- the below will occur - Makes Player Motion independent of the Rover --- NEW SECTIOn
        if (c.CamMode == 1)
        {
            //Debug.Log("New Frame -----------");

            // boolean for if the character is on the ground
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // if its on the ground and falling
            if (isGrounded)
            {
                // if jumping, when back on ground
                isJumping = false;

                if (velocity.y < 0 && !isJumping)
                {
                    // keeps object grounded when not jumping (ex. down a slope)
                    //Debug.Log("Grounded");
                    velocity.y = -10000f;
                }

                // grounded opens the option to jump
                if (Input.GetKeyDown("space"))
                {
                    //Debug.Log("Jumping")
                    velocity.y = jumpAcceleration;
                    isJumping = true;
                }
            }

            // gets if the WASD keys are pushed down
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                // sprinting
                //Debug.Log("Sprinting");
                speed = 5f;
            }
            else if (Input.GetKey("z"))
            {
                // cheat speed mode
                speed = 1000f;
            }
            else
            {
                // walking
                //Debug.Log("Walking");
                speed = normalSpeed;
            }

            // moving x (forwards, backwards, left, right)
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            // gravity making fall down
            velocity.y -= gravity * Time.deltaTime;
            //Debug.Log(velocity.y);
            // multiply by 0.5?
            controller.Move(velocity * Time.deltaTime);

        }
    }
}
