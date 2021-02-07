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

    public Text earthElevationIndicator;
    public Text earthAzimuthIndicator;

    public Texture2D heightImage;
    public Texture2D signImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        
        // NEED TO CHANGE THIS TO USING A RAYCAST TO FIND DIFFERENCE BETWEEN Y AND GROUND BELOW AND APPLY THAT
        // RATHER THAN JUST TAKING Y 
        // AS THIS SHOULD BE HEIGHT OF GROUND, NOT Y OF PLAYER (LIKE IF JUMPS, SHOULDN'T CHANGE VALUE IF STAY IN SAME SPOT)
        // Also: use time.deltaTime or something liek that so that it only updates every half second or somethign
        // that way it doesn't look all stuttery
        heightIndicator.text = (Mathf.Round(transform.position.y*100f)/100f).ToString();
        // need to find a way to ensure always 2 decimal points, rather than going to just 1 dec. point when ends with 0
        xIndicator.text = (Mathf.Round(x)).ToString();
        yIndicator.text = (Mathf.Round(z)).ToString();
        zIndicator.text = (Mathf.Round(y)).ToString();
        //Debug.Log("Start");
        //Debug.Log((transform.position.y*-1)/1737400f);
        //Debug.Log(Mathf.Rad2Deg * Mathf.Asin((transform.position.y*-1)/1737400f));

        /*
        int x = (int) Mathf.Round(transform.position.x/40f + 1514);
        int y = (int) Mathf.Round(transform.position.z/40f + 1514);
        Debug.Log("X: " + x.ToString());
        Debug.Log("Y: " + y.ToString());

        Color heightPosition = heightImage.GetPixel(x, y);
        float height = (heightPosition.r*255f*100f) + (heightPosition.g*255f) + (heightPosition.g*255f/100f);
        Debug.Log(heightPosition.ToString());
        Debug.Log("Sign: " + signImage.GetPixel(x,y).ToString());
        
        Color signPosition = signImage.GetPixel(x, y);
        if(signPosition.r == 0)
        {
            height *= -1f;
        }
        
        Debug.Log("Height: " + height.ToString());
        */

        float distance = Mathf.Sqrt((x*x) + (z*z));
        //Debug.Log("Distance: " + distance.ToString());

        float latitude = -90 + Mathf.Rad2Deg * Mathf.Atan2(distance, 1737400f);
        //Debug.Log("Latitude: " + latitude.ToString());

        float height = y/Mathf.Sin(Mathf.Deg2Rad * latitude);
        //Debug.Log("Height: " + height.ToString());

        float longitude = Mathf.Rad2Deg * Mathf.Acos(x/((1737400 + height) * Mathf.Cos(Mathf.Deg2Rad * latitude)));
        float sinLongitude = Mathf.Rad2Deg * Mathf.Asin(z/((1737400 + height) * Mathf.Cos(Mathf.Deg2Rad * latitude)));

        if(sinLongitude < 0)
        {
            longitude *= -1;
        }

        //Debug.Log("Longitude: " + longitude.ToString());

        latIndicator.text = (Mathf.Round(latitude*100f)/100f).ToString();
        lonIndicator.text = (Mathf.Round(longitude*100f)/100f).ToString();

        float changeX = 361000000f - x;
        float changeY = -42100000f - y;
        float changeZ = 0f - z;

        float earthDist = Mathf.Sqrt((changeX*changeX) + (changeY*changeY) + (changeZ*changeZ));

        float rz1 = changeX * Mathf.Cos(Mathf.Deg2Rad * latitude) * Mathf.Cos(Mathf.Deg2Rad * longitude);
        float rz2 = changeY * Mathf.Cos(Mathf.Deg2Rad * latitude) * Mathf.Sin(Mathf.Deg2Rad * longitude);
        float rz3 = changeZ * Mathf.Sin(Mathf.Deg2Rad * latitude);
        float rz = rz1 + rz2 + rz3;

        float earthElevation = Mathf.Rad2Deg * Mathf.Asin(rz/earthDist);

        earthElevationIndicator.text = (Mathf.Round(earthElevation*100f)/100f).ToString();










        /*
        //OLD
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
        */
    }
}
