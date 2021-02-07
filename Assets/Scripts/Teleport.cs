using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{

    public RawImage teleportMenu;
    public Transform player;
    public CharacterController characterController;
    public Terrain terrain;

    public InputField x;
    public InputField y;
    
    public megamap map;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(teleportMenu.rectTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(map.isBig)
        {
            teleportMenu.rectTransform.position = new Vector2(199.6f, 432.5f);
        }
        else
        {
            teleportMenu.rectTransform.position = new Vector2(-9999f, -9999f);
            x.text = "";
            y.text = "";
        }
        
        //Debug.Log(teleportMenu.rectTransform.position);
        /*
        if(Input.GetKey("t"))
        {
            teleportPlayer(0f, 0f);
        }
        */
    }

    public void teleportButtonPress()
    {
        teleportPlayer(float.Parse(x.text), float.Parse(y.text));
        x.text = "";
        y.text = "";
    }


    public void teleportPlayer(float x, float z)
    {
        Vector3 dest = new Vector3(x, 0, z);
        float y = terrain.SampleHeight(dest);
        dest.y = y + 1.85f;

        characterController.enabled = false;
        player.position = dest;
        //maybe the sampleheight isn't working and it's teleporting me into the air and it's the character controller
        //that's pulling me down, but why am i still able to slow jump then?
        characterController.enabled = true;
    }
}
