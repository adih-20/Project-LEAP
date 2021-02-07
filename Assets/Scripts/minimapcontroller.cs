using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapcontroller : MonoBehaviour
{

    public megamap mm;

    // Update is called once per frame
    public GameObject player;
    void Update()
    {
        float y = this.GetComponent<Camera>().transform.position.y;
        float x = this.GetComponent<Camera>().transform.position.x;
        float z = this.GetComponent<Camera>().transform.position.z;
        float dVert = Input.GetAxis("dVert");
        float dHoriz = Input.GetAxis("dHoriz");
        float size = this.GetComponent<Camera>().orthographicSize;
        //Debug.Log(size);

        bool big = mm.isBig;

        if(!big)
        {
            float x2 = player.transform.position.x;
            float z2 = player.transform.position.z;
            this.GetComponent<Camera>().transform.position = new Vector3(x2, y, z2);
        }

        if (Input.GetKey("q"))
        {
            if (size < 30000)
            {
                this.GetComponent<Camera>().orthographicSize = size + 100;
            }
        }
        if (Input.GetKey("e"))
        {
            if (size > 1000)
            {
                this.GetComponent<Camera>().orthographicSize = size - 100;
            }
        }
        if (big && (Input.GetKey("j") || dHoriz < -0.3))
        {
            x -= 10000 * (75f/this.GetComponent<Camera>().orthographicSize);
            if (this.GetComponent<Camera>().transform.position.x < -60000)
            {
                x += 10000 * (75/this.GetComponent<Camera>().orthographicSize);
                this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
            }
            this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
        }
        if (big && (Input.GetKey("l")  || dHoriz > 0.3))
        {
            x += 10000 * (75/this.GetComponent<Camera>().orthographicSize);
            if (this.GetComponent<Camera>().transform.position.x > 60000)
            {
                x -= 10000 * (75/this.GetComponent<Camera>().orthographicSize);
                this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
            }
            this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
        }
        if (big && (Input.GetKey("i") || dVert > 0.5))
        {
            z += 10000 * (75/this.GetComponent<Camera>().orthographicSize);
            if (this.GetComponent<Camera>().transform.position.z > 60000)
            {
                z -= 10000 * (75/this.GetComponent<Camera>().orthographicSize);
                this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
            }
            this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
        }
        if (big && (Input.GetKey("k")  || dVert < -0.3))
        {
            z -= 10000 * (75/this.GetComponent<Camera>().orthographicSize);
            if (this.GetComponent<Camera>().transform.position.z < -60000)
            {
                z += 10000 * (75/this.GetComponent<Camera>().orthographicSize);
                this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
            }
            this.GetComponent<Camera>().transform.position = new Vector3(x, y, z);
        }
    }
}
