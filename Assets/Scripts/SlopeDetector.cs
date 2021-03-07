using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlopeDetector : MonoBehaviour
{
    
    // public float groundSlopeAngle = 0f;
    // private Vector3 groundSlopeDir;

    public Text indicator;

    public RawImage dataPanel;

    public Texture normalPanel;
    public Texture slopeWarning;


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        /*
        if(Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            //Debug.Log("something");
        }
        else
        {
            //Debug.Log("nothing");
        }
        */

        //Debug.Log(hit.normal);
        //Debug.Log(Vector3.Angle(hit.normal, Vector3.up));

        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);
        float slope = Vector3.Angle(hit.normal, Vector3.up);
        indicator.text = (Mathf.Round(slope * 100)/100f).ToString();


        if (slope > 15)
        {
            dataPanel.texture = slopeWarning;
            indicator.color = Color.red;
        }
        else
        {
            dataPanel.texture = normalPanel;
            indicator.color = Color.white;
        }
    }
}
