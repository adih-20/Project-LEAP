using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthVisibiltyCasting : MonoBehaviour
{
    public Transform target; //This public object helps locate what to aim linecast at
    public RaycastHit hit; //Structure to receive info on what is hit - Testing usage
    public LayerMask layer; //Used to determine the layer we ONLY want to detect when using linecast

    //These variables determine the offset location of the linecast endpoint - if needed
    private float x = 0f;
    private float y = 850f;
    private float z = 0f;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 shift = new Vector3(x, y, z); //Create a new vector to add and offset linecast origin

        //Draw Linecast from Player position to Target(Earth Position), Pass info to check what is hit, exclusive layer
        if(Physics.Linecast(transform.position, target.position + shift, out hit, layer))
        {
            Debug.DrawLine(transform.position, target.position + shift, Color.red);
            Debug.Log("Earth Is Not Visible");
        }

        else
        {
            Debug.DrawLine(transform.position, target.position + shift, Color.green);
            Debug.Log("Earth Is Visible");
        }

        if (hit.collider == null)
        {
            Debug.Log(target.gameObject.name);
        }

        else
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
