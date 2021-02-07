using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconSize : MonoBehaviour
{
    
    public Transform player;

    public Vector3 defaultScale = new Vector3(8f, 40000f, 8f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();

        float beaconX = transform.position.x;
        float beaconY = transform.position.z;
        float playerX = player.position.x;
        float playerY = player.position.z;

        float distance = Mathf.Sqrt(Mathf.Pow(beaconX - playerX, 2f) + Mathf.Pow(beaconY - playerY, 2f));
        //Debug.Log(distance);

        if(distance < 15000f)
        {
            transform.localScale = (defaultScale + new Vector3(distance/100f, 0f, distance/100f));
        }
        else if (distance >= 15000f && distance < 30000f)
        {
            float multiplier = Mathf.Pow(2f, -1*((distance-20000f)/8000f));
            Debug.Log(multiplier);
            // value before multiplier is the maximum scale the beam would be at max distance, which at the time of this writing is 15000
            transform.localScale = new Vector3(158f * multiplier, 40000f, 158f * multiplier);
        }
        else
        {
            transform.localScale = new Vector3(0f, 0f, 0f);
        }


        /*
        if(distance <= 2000)
        {
            transform.localScale = defaultScale;
        }
        else if (distance > 200 && distance <= 20000)
        {
            transform.localScale = (defaultScale + new Vector3(distance/75f, 0f, distance/75f));
        }
        else
        {
            transform.localScale = defaultScale;
        }
        */

    }
}
