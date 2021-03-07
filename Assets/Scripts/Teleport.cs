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

    public RawImage savedLocations;
    public InputField notes;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(teleportMenu.rectTransform.position);
        notes.text = "Communication Link #1: 22714, -8222\nCommunication Link #2: 22649, -7631\nCommunication Link #3: 22566, -8721\nCommunication Link #4: 22309, -9125\nCommunication Link #5: 22185, -9376\nCommunication Link #6: 21791, -9615\nCommunication Link #7: 21606, -9760\nCommunication Link #8: 21518, -10088\nCommunication Link #9: 21154, -10430\nCommunication Link #10: 20909, -10812\nCommunication Link #11: 20966, -11197\nCommunication Link #3: 20895, -12414";
    }

    // Update is called once per frame
    void Update()
    {
        ///*
        if(map.isBig)
        {
            teleportMenu.rectTransform.position = new Vector2(359.8f, 295.4f);
            savedLocations.rectTransform.position = new Vector2(360f, 595.9f);
            //notes.ActivateInputField();
            //notes.MoveTextEnd();
        }
        else
        {
            teleportMenu.rectTransform.position = new Vector2(-9999f, -9999f);
            savedLocations.rectTransform.position = new Vector2(-9999f, -9999f);
            x.text = "";
            y.text = "";
            notes.DeactivateInputField();
        }
        //*/
        
        //Debug.Log(savedLocations.rectTransform.position);

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
