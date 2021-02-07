using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOfInterest : MonoBehaviour
{
    
    public GameObject redBeacon;

    public Transform placementPoint;

    //2d array of pois here
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("b"))
        {
            Instantiate(redBeacon, placementPoint.position - new Vector3(0f, -6000f, 0f), Quaternion.identity);
        }
    }
}
