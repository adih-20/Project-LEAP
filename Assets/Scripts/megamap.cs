using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class megamap : MonoBehaviour
{

    public Texture none;
    public Texture arr;

    public bool isBig = false;

    public RawImage arrow;

    void Start()
    {
        this.GetComponent<RawImage>().rectTransform.sizeDelta = new Vector2(125, 125);

        float x = canvas.transform.position.x;
        float y = canvas.transform.position.y;
        this.GetComponent<RawImage>().rectTransform.position = new Vector2((float)1.75*x ,(float) 1.6*y);
        this.GetComponent<RawImage>().rectTransform.sizeDelta = new Vector2(125, 125);
        arrow.GetComponent<RawImage>().texture = arr;
    }

    // Update is called once per frame
    public GameObject canvas;
    void Update()
    {
        float x = canvas.transform.position.x;
        float y = canvas.transform.position.y;
        if (Input.GetKeyDown(KeyCode.Tab) || (Input.GetKeyDown("joystick button 7")))
        {
            if(this.GetComponent<RawImage>().rectTransform.rect.width == 125)
            {
                //make big
                //this.GetComponent<RawImage>().rectTransform.position = new Vector2(260, 277);
                this.GetComponent<RawImage>().rectTransform.position = new Vector2(x+185,y);
                //this.GetComponent<RawImage>().rectTransform.position = new Vector2(336,159);
                this.GetComponent<RawImage>().rectTransform.sizeDelta = new Vector2(425, 425);
                isBig = true;
                arrow.GetComponent<RawImage>().texture = none;
            }
            else
            {
                //make small
                //this.GetComponent<RawImage>().rectTransform.position = new Vector2(430, 447);
                this.GetComponent<RawImage>().rectTransform.position = new Vector2((float)1.75*x ,(float) 1.6*y);
                this.GetComponent<RawImage>().rectTransform.sizeDelta = new Vector2(125, 125);
                isBig = false;
                arrow.GetComponent<RawImage>().texture = arr;
            }
        }
    }
}
