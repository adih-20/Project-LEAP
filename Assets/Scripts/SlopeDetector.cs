using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeDetector : MonoBehaviour
{
    
    public float groundSlopeAngle = 0f;
    private Vector3 groundSlopeDir;

    


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            Debug.Log("something");
        }
        else
        {
            Debug.Log("nothing");
        }

        Debug.Log(hit.normal);
        Debug.Log(Vector3.Angle(hit.normal, Vector3.up));
    }
}
