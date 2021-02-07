using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 1f, 0f*Time.deltaTime);

    }
}
