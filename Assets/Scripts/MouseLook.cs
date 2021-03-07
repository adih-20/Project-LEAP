using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    // first person player object
    public Transform playerBody;

    public PlayerMovement pm;

    float xRotation = 0f;

    public float variationAmplitude = 0.4f;
    public float variationTime = 0f;
    public float walkVariationFrequency = 5f;
    public float sprintVariationFrequency = 7f;

    public Vector3 cameraHeight =  new Vector3(0f, 1.49f, 0f);
    public Vector3 cameraPosition;

    public megamap map;

    public PauseScreen pause;

    // Start is called before the first frame update
    void Start()
    {
        // hide cursor at center of screen
        //Cursor.lockState = CursorLockMode.Locked;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(!(map.isBig) && !(pause.paused))
        {
            // hide cursor at center of screen
            Cursor.lockState = CursorLockMode.Locked;
            // Time.deltaTime is the amount of time since last Update() was called to ensure consistency between 
            // different frame rates (on differently powerfu computers)
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // this system differs from the x so we can use clamp
            xRotation -= mouseY;
            // ensure that it'll never over-rotate
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // look around using mouseX (only)
            playerBody.Rotate(Vector3.up * mouseX);

            //get the camera's current position with offset
            cameraPosition = playerBody.transform.position + cameraHeight;
            Vector3 offset;

            if((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && pm.isGrounded)
            {
                // if moving and not jumping, then make camera variations per frame
                variationTime += Time.deltaTime;
                
                //different variation frequencies for walking and sprinting based off of time and sine function
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    offset = new Vector3(0, variationAmplitude * Mathf.Sin(sprintVariationFrequency * variationTime), 0);
                }
                else
                {
                    offset = new Vector3(0, variationAmplitude * Mathf.Sin(walkVariationFrequency * variationTime), 0);
                }
                
                offset += cameraPosition;
                transform.position = offset;
            }
            else
            {
                // otherwise, keep camera in the fixed position (not moving)
                transform.position = cameraPosition;
                //reset timer for variations
                variationTime = 0f;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
