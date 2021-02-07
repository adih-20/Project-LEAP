using UnityEngine;

public class RoverMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero; //The direction we want the rover to move

    private float gravity = 500f; //Unrealistic - Just to quickly pull down rover, can't jump but there in case

    private float turnSpeed = 35.0f; //How fast can the rover rotate

    private float speed = 300f;//may appear fast, but in reality, the map is so huge, so this speed is not much

    private Vector3 mountOff; //Declaring a vector that will help us offset the first person character

    private CharacterController controller; //Movement Controller of Our Rover(this.GameObject)

    public CamSwitch c; //Access the CamSwitch Script as An Object - Allow us to access which "Game mode" we are in to constrain rover movement

    public GameObject t; //Our first person player, we need to relocate him/her when we are in rover mode

    void Start()
    {
        controller = this.GetComponent<CharacterController>(); //Establishing our Character Controller(Within the MMSEV gameobject)

        c = (CamSwitch)FindObjectOfType(typeof(CamSwitch)); //Saying that our script object c is a going to be a object script reference of the CamSwitch Script

        mountOff = new Vector3(0.0f, 100.0f, 0.0f); //Feel free to modify this - Player will be on TOP of rover - Change as you see fit
    }


    void Update()
    {
        //CamMode is an integer variable from the CamSwitch Script, this allows use to access it for constraining rover movement

        //If the camMode Attribute is 0 - the below will occur - Makes rover motion independent of the Player
        if (c.CamMode == 0)  
        {
            if (controller.isGrounded) //Horizontal Motion
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            }

            float turn = Input.GetAxis("Horizontal"); //Measures the magnitude of A and D keys for turning

            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0); //Actual turning motion occurs here

            controller.Move(moveDirection * Time.deltaTime); //Character controller forward motion

            moveDirection.y -= gravity * Time.deltaTime; //Account for gravity, the eternal force

            t.transform.position = this.gameObject.transform.position + mountOff; //This shifts our first person player position(to top) when rover mode is ON
        }
    }
}
