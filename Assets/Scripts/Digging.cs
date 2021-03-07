using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{
    public ParticleSystem ps;
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            on = !on;
            if(on)
            {
                ps.Play();
            } else
            {
                ps.Stop();
            }
        }
    }
}
