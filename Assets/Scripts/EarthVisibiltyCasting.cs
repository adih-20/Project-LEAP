using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthVisibiltyCasting : MonoBehaviour
{
    public Transform target; //This public object helps locate what to aim linecast at
    public Vector3 hardTarget = new Vector3(361000000, 0, -42100000);
    public RaycastHit hit; //Structure to receive info on what is hit - Testing usage
    public LayerMask layer; //Used to determine the layer we ONLY want to detect when using linecast

    //These variables determine the offset location of the linecast endpoint - if needed
    private float x = 0f;
    private float y = 850f;
    private float z = 0f;

    public Image indicator;
    //R:255, G:47, B:0, A:255
    Color notVisible = new Color(1.0f, 0.18f, 0f, 1f);
    //R:4, G:183, B:1, A:255
    Color visible = new Color(0.02f, 0.72f, 0f, 1f);
    
    // Update is called once per frame
    void Update()
    {
        Vector3 shift = new Vector3(x, y, z); //Create a new vector to add and offset linecast origin

        //Draw Linecast from Player position to Target(Earth Position), Pass info to check what is hit, exclusive layer
        if(Physics.Linecast(transform.position, hardTarget + shift, out hit, layer))
        {
            Debug.DrawLine(transform.position, hardTarget + shift, Color.red);
            //Debug.Log("Earth Is Not Visible");
            indicator.color = notVisible;
        }

        else
        {
            Debug.DrawLine(transform.position, hardTarget + shift, Color.green);
            //Debug.Log("Earth Is Visible");
            indicator.color = visible;
        }

        if (hit.collider == null)
        {
            //Debug.Log(target.gameObject.name);
        }

        else
        {
            //Debug.Log(hit.collider.gameObject.name);
        }
    }
}
