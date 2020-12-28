using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapArrow : MonoBehaviour
{
    public Transform playerBodyTransform;
    public Transform arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z_arrow = arrow.localEulerAngles.z;
        float z_player = playerBodyTransform.localEulerAngles.y;

        //Debug.Log(z_arrow + " " + z_player + " " + (z_player - z_arrow));
        arrow.Rotate(0f, 0f, (-1*(z_player) - z_arrow), Space.Self);
    }
}
