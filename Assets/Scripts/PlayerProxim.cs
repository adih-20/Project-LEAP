using UnityEngine;
using UnityEngine.UI;

public class PlayerProxim : MonoBehaviour
{
    //Our linecast target is the First Person Player
    public Transform target;

    //This is the layer that if the linecast hits(terrain), the mode switching mechamism won't work
    public LayerMask layer;

    //Raycast variable that provides hit info from the linecast
    RaycastHit hit;

    //these three variables are used for slight shifting of origin of the ray - you can delete these, unnecessary
    private float x = 0f;
    private float y = 0.8f;
    private float z = 0f;

    //We are creating a boolean to indicate if we are close enough to the rover to change modes of play
    public bool proximity;

    //We use this in the inspector to tell us how close we are from the rover
    //Remember, 200 m or less means we can switch modes
    public float dist;

    // Update is called once per frame
    void Update()
    {

        //Measuring the distance between the rover and the player, this determines proximitiy
        dist = Vector3.Distance(target.transform.position, gameObject.transform.position);


        //Not something to worry about - IGNORE anything about shift - you can get rid of it
        Vector3 shift = new Vector3(x, y, z);

        //If the linecast hits any terrain...
        if (Physics.Linecast(transform.position + shift, target.position, out hit, layer) == true)
        {
            //Debug.Log("Blocked");
            Debug.DrawLine(transform.position + shift, target.position, Color.red);

            //The proximity variable will obviously be false
            proximity = false;
        }

        //if the linecast doesn't hit any terrain...
        else
        {
            //Debug.Log("Visible");

            //You MIGHT be able to hop into the rover
            Debug.DrawLine(transform.position + shift, target.position, Color.green);

            //But the distance has to be within 200 units for you do to so..
            if (dist <= 200f)
            {
                //If you are close enough the proximity will be true, and you can hop in
                proximity = true;
                Debug.DrawLine(transform.position + shift, target.position, Color.cyan);
                Debug.Log("The player is within 200 units of the rover and can hop inside!(PlayerProxim.cs)");
            }

            else
            {
                //If you are in sight of the rover, but not within 200 meters, tough luck!
                proximity = false;
            }
        }
    }
}