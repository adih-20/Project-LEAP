using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI
{
    public float x;
    public float y;

    public float lat;

    public float lon;
    
    public string name;

    public int color;
    
    
    // Start is called before the first frame update
    public POI(float x, float y, float lat, float lon, string name, int color)
    {
        this.x = x;
        this.y = y;
        this.lat = lat;
        this.lon = lon;
        this.name = name;
        this.color = color;
    }

    public POI(float x, float y, string name, int color, LocationIndicators player)
    {
        //todo: consolidate all datapanel stuff into one script
        //either teleport forward to the beacon for 1 frame and then back
        //or consolidate script and put it onto an invisible gameobject and have it calculate coords there
        this.x = x;
        this.y = y;
        //this.lon = player.longitude; AS OF RN, THESE VARIABLES ARE ONLY IN THE UPDATE, NEED TO MAKE THEM OUT IN THE OPEN
        //this.lat = player.lat;
        this.name = name;
        this.color = color;
    }

}
