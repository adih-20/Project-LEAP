using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationIndicators : MonoBehaviour
{

    public Text heightIndicator;
    public Text xIndicator;
    public Text yIndicator;
    public Text zIndicator;

    public Text latIndicator;
    public Text lonIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // NEED TO CHANGE THIS TO USING A RAYCAST TO FIND DIFFERENCE BETWEEN Y AND GROUND BELOW AND APPLY THAT
        // RATHER THAN JUST TAKING Y 
        // AS THIS SHOULD BE HEIGHT OF GROUND, NOT Y OF PLAYER (LIKE IF JUMPS, SHOULDN'T CHANGE VALUE IF STAY IN SAME SPOT)
        // Also: use time.deltaTime or something liek that so that it only updates every half second or somethign
        // that way it doesn't look all stuttery
        heightIndicator.text = (Mathf.Round(transform.position.y*100f)/100f).ToString();
        // need to find a way to ensure always 2 decimal points, rather than going to just 1 dec. point when ends with 0
        xIndicator.text = (Mathf.Round(transform.position.x)).ToString();
        yIndicator.text = (Mathf.Round(transform.position.z)).ToString();
        zIndicator.text = (Mathf.Round(transform.position.y)).ToString();

        //calculating latitude and longitude
        float changeX = 361000000f - (transform.position.x);
        float changeY = 0f - (transform.position.y);
        float changeZ = -42100000f - (transform.position.z);

        float earthDist = (changeX * changeX) + (changeY * changeY) + (changeZ * changeZ);

        float earthLat = (Mathf.Asin(-42100000/earthDist));
        //Debug.Log("Lat: ");
        //Debug.Log(earthLat);
        //latIndicator.text = (Mathf.Round(earthLat*100f)/100f).ToString();
        float earthLon = Mathf.Rad2Deg * (Mathf.Asin(0/(earthDist * Mathf.Cos(earthLat))));
        //lonIndicator.text = (Mathf.Round(earthLon*100f)/100f).ToString();



        //float personLon = Mathf.Rad2Deg * (Mathf.Asin((transform.position.y)/1737400f));
        //Debug.Log("PersonLon: ");
        //Debug.Log(personLon);

        // elevation calculation
        float rz1 = changeX * Mathf.Cos(Mathf.Deg2Rad * (earthLat))*Mathf.Cos(Mathf.Deg2Rad * (earthLon));
        float rz2 = changeY * Mathf.Cos(Mathf.Deg2Rad * (earthLat))*Mathf.Sin(Mathf.Deg2Rad * (earthLon));
        float rz3 = changeZ * Mathf.Sin(Mathf.Deg2Rad * (earthLat));

        float rz = rz1 + rz2 + rz3;

        float elevation = Mathf.Rad2Deg * (Mathf.Asin(rz/earthDist));
        //Debug.Log("Elevation: ");
        //Debug.Log(elevation);
    }
}
