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
    public Material illumination;
    public int counter = 1;
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
 
    private float runtime;
 
    public bool party;
    public Text partyText;
 
    //string[] keyScale = {"", "", "", "", ""};
 
    // Start is called before the first frame update
    void Start()
    {
        party = false;
        partyText.text = "";
 
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
 
      runtime += 4*Time.deltaTime;
      if(Input.GetKeyDown("joystick button 4")
            if(counter != 1){
              counter--;
            }
            else {
              counter = 6;
            }
      } else if(Input.GetKeyDown("joystick button 5"))
      {
          if(counter != 6) {
            counter++;
          }
          else {
            counter = 1;
          }
      }
      if(Input.GetKeyDown("f1")){
        counter = 1;
      }
      else if(Input.GetKeyDown("f2")){
        counter = 2;
      }
      else if(Input.GetKeyDown("f3")){
        counter = 3;
      }
      else if(Input.GetKeyDown("f4")){
        counter = 4;
      }
      else if(Input.GetKeyDown("f5")){
        counter = 5;
      }
      else if(Input.GetKeyDown("f6")){
        counter = 6;
      }
 
        if(counter == 1)
        {
            party = false;
            partyText.text = "";
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
 
        else if(counter == 2)
        {
            party = false;
            partyText.text = "";
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
 
        else if(counter == 3)
        {
            party = false;
            partyText.text = "";
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
        else if(counter == 4)
        {
            party = false;
            partyText.text = "";
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
 
        else if(counter == 5)
        {
            party = false;
            partyText.text = "";
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
 
        else if(counter == 6)
        {
          terrain.materialTemplate = illumination;
          scale_obj.texture = none_img;
          //keys.texture = az_angle_key;
          upper.text = "";
          upperMid.text = "";
          mid.text = "";
          lowerMid.text = "";
          lower.text = "";
 
          label.text = "ILLUMINATION";
          units.text = "";
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            party = true;
        }
        
        if(party)
        {
            partyText.text = "PARTY!";
            scale_obj.texture = none_img;
            upper.text = "";
            upperMid.text = "";
            mid.text = "";
            lowerMid.text = "";
            lower.text = "";
 
            label.text = "";
            units.text = "";
            int cycle = (int)(runtime % 4);
            if(cycle < 1)
            {
                terrain.materialTemplate = height;
                partyText.color = Color.magenta;
            }
            if(cycle >= 1 && cycle < 2)
            {
                terrain.materialTemplate = slope;
                partyText.color = Color.yellow;
            }
            else if(cycle >= 2 && cycle < 3)
            {
                terrain.materialTemplate = elevation_angle;
                partyText.color = Color.cyan;
            }
            else if(cycle >= 3 && cycle < 4)
            {
                terrain.materialTemplate = azimuth_angle;
                partyText.color = Color.green;
            }
        }
        
        /*
        upper.text = keyScale[0];
        upperMid.text = keyScale[1];
        mid.text = keyScale[2];
        lowerMid.text = keyScale[3];
        lower.text = keyScale[4];
        */
 
        // Using switch-case statement for ease of use over long, winded if-else statements.
        // THIS BREAKS KEYBOARD!
        /*switch(counter)
        {
          case 1:
                terrain.materialTemplate = moon;
                scale_obj.texture = none_img;
                //keys.texture = none;
                /*
                for(int i = 0; i < 5; i++)
                {
                    keyScale[i] = "";
                }
                */ /*
                upper.text = "";
                upperMid.text = "";
                mid.text = "";
                lowerMid.text = "";
                lower.text = "";
 
                label.text = "";
                units.text = "";
                break;
            case 2:
                terrain.materialTemplate = height;
                scale_obj.texture = key_img;
                //keys.texture = height_key;
                upper.text = "4247.96";
                upperMid.text = "2696.50";
                mid.text = "1145.03";
                lowerMid.text = "-406.44";
                lower.text = "-1957.91";
 
                label.text = "HEIGHT";
                units.text = "m";
                break;
            case 3:
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
                break;
            case 4:
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
                break;
            case 5:
                terrain.materialTemplate = azimuth_angle;
                scale_obj.texture = key_img;
                //keys.texture = az_angle_key;
                upper.text = "";
                upperMid.text = "";
                mid.text = "";
                lowerMid.text = "";
                lower.text = "";
 
                label.text = "AZIMUTH TO EARTH";
                units.text = "deg";
                break;
            default:
                break;
            } */
 
      }
    }
 
 

