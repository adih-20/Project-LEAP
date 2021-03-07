using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOfInterest : MonoBehaviour
{
    
    public GameObject redBeacon;

    public Transform placementPoint;

    //2d array of pois here
    public List<POI> pois = new List<POI>();
    
    // Start is called before the first frame update
    void Start()
    {
        pois.Add(new POI(22714f, -8222f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(22649f, -7631f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(22566f, -8721f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(22309f, -9125f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(22185f, -9376f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(21791f, -9615f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(21606f, -9760f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(21518f, -10088f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(21154f, -10430f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(20909f, -10812f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(20966f, -11197f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(20895f, -12414f, 1f, 1f, "Communication Link Point #1", 0));
        pois.Add(new POI(19303f, 14968f, 1f, 1f, "Sample Mission Location", 1));
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
