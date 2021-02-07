using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamSwitch : MonoBehaviour
{
    //Access the PlayerProxim.cs Script as An Object - Allow us to know if our player is in close "proximity" to the rover
    public PlayerProxim prCast; 

    //By default, you will play in first person mode
    public int CamMode = 1;

    private void Start()
    {
        //Saying that our script object prCast is a going to be a object script reference of the PlayerPrxoim Script
        prCast = (PlayerProxim)FindObjectOfType(typeof(PlayerProxim));
    }

    private void Update()
    {
        //We are pulling the proximity reading using our prCast object
        //Proximity is true if we are within 200 units of the rover(Rover is quite large so should be good)
        if (prCast.proximity)
        {
            //IMPORTANT - F key is designated as rover switching
            if (Input.GetKeyDown("f"))
            {
                //If f is pressed and we are in range, and first person, switch to rover mode
                if (CamMode == 1)
                {
                    CamMode = 0;
                }

                //If you are in rover mode and click F, you will change back to first person
                else
                {
                    CamMode += 1;
                }
            }
        }
    }
}
