using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataViewer2 : MonoBehaviour
{

    public Transform player;
    public Texture2D key;
    public Text thetext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //(player.position.x + 60000)/120000
        //Debug.Log(Mathf.Round(((player.position.x + 60000)/120000)*2048));
        //Debug.Log(Mathf.Round(((player.position.z + 60000)/120000)*2048));

        int x = (int) Mathf.Round(((player.position.x + 60000)/120000)*2048);
        int y = (int) Mathf.Round(((player.position.z + 60000)/120000)*2048);
        Color slope = key.GetPixel(x, y);
        float sloper = ((slope.r)*65);
        Debug.Log(sloper);
        thetext.text = "SLOPE (approx.):\n" + (Mathf.Round(sloper*100f)/100f).ToString() + " DEG";

    }
}
