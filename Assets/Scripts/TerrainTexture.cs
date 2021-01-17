using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainTexture : MonoBehaviour
{
    
    public Terrain terrain;

    public Material moon;
    public Material height;
    public Material slope;
    public Material elevation_angle;
    public Material azimuth_angle;
    
    /*
    public RawImage keys;
    public Texture none;
    public Texture height_key;
    public Texture slope_key;
    public Texture el_angle_key;
    public Texture az_angle_key;
    */

    public RawImage scale_obj;

    public Texture none_img;
    public Texture key_img;

    public Text upper;
    public Text upperMid;
    public Text mid;
    public Text lowerMid;
    public Text lower;

    public Text label;
    public Text units;

    //string[] keyScale = {"", "", "", "", ""};

    // Start is called before the first frame update
    void Start()
    {
        terrain.materialTemplate = moon;
        scale_obj.texture = none_img;
        //keys.texture = none;

        upper.text = "";
        upperMid.text = "";
        mid.text = "";
        lowerMid.text = "";
        lower.text = "";

        label.text = "";
        units.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            terrain.materialTemplate = moon;
            scale_obj.texture = none_img;
            //keys.texture = none;
            /*
            for(int i = 0; i < 5; i++)
            {
                keyScale[i] = "";
            }
            */
            upper.text = "";
            upperMid.text = "";
            mid.text = "";
            lowerMid.text = "";
            lower.text = "";

            label.text = "";
            units.text = "";
        }
        else if(Input.GetKeyDown("2"))
        {
            terrain.materialTemplate = height;
            scale_obj.texture = key_img;
            //keys.texture = height_key;

            upper.text = "1957.91";
            upperMid.text = "406.44";
            mid.text = "-1145.03";
            lowerMid.text = "-2696.50";
            lower.text = "-4247.96";

            label.text = "HEIGHT";
            units.text = "m";
        }
        else if(Input.GetKeyDown("3"))
        {
            terrain.materialTemplate = slope;
            scale_obj.texture = key_img;
            //keys.texture = slope_key;
            upper.text = "65";
            upperMid.text = "48.75";
            mid.text = "32.5";
            lowerMid.text = "16.25";
            lower.text = "0";
            
            label.text = "SLOPE";
            units.text = "deg";
        }
        else if(Input.GetKeyDown("4"))
        {
            terrain.materialTemplate = elevation_angle;
            scale_obj.texture = key_img;
            //keys.texture = el_angle_key;
            upper.text = "8.65";
            upperMid.text = "7.65";
            mid.text = "6.65";
            lowerMid.text = "5.65";
            lower.text = "4.65";
            
            label.text = "ELEVATION TO EARTH";
            units.text = "deg";
        }
        else if(Input.GetKeyDown("5"))
        {
            terrain.materialTemplate = azimuth_angle;
            scale_obj.texture = key_img;
            //keys.texture = az_angle_key;
            upper.text = "0";
            upperMid.text = "90";
            mid.text = "180";
            lowerMid.text = "270";
            lower.text = "360";
            
            label.text = "AZIMUTH TO EARTH";
            units.text = "deg";
        }

        /*
        upper.text = keyScale[0];
        upperMid.text = keyScale[1];
        mid.text = keyScale[2];
        lowerMid.text = keyScale[3];
        lower.text = keyScale[4];
        */
    }
}
