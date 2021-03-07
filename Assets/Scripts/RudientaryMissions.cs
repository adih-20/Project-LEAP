using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RudientaryMissions : MonoBehaviour
{
    
    public Transform player;

    public Texture alldone;
    public Texture inProgress;
    public Texture completed;
    public Texture transparent;

    public RawImage bg;
    public RawImage m1;
    public RawImage m2;
    public RawImage m3;

    public Text m1T;
    public Text m2T;
    public Text m3T;

    public int stage;

    public Vector3 m1Target = new Vector3(19303f, -998f, 14968f);

    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
        m1T.color = Color.white;
        m2T.color = Color.gray;
        m3T.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float distX = player.position.x - m1Target.x;
        float distZ = player.position.z - m1Target.y;
        Debug.Log("X2" + player.position.x.ToString());
        Debug.Log("Y2" + player.position.z.ToString());
        Debug.Log("X1" + m1Target.x.ToString());
        Debug.Log("Y1" + m1Target.y.ToString());

        float dist = Mathf.Sqrt((distX*distX) + (distX*distX));
        Debug.Log("D" + Mathf.Round(dist).ToString());
        */
        if((distanceTo(m1Target) < 30f) && stage == 1)
        {
            m1.texture = completed;
            m1T.color = Color.gray;
            m2T.color = Color.white;
            stage++;
        }
        
        if(Input.GetMouseButtonDown(1) && stage == 2)
        {
            m2.texture = completed;
            m2T.color = Color.gray;
            m3T.color = Color.white;
            stage++;
        }

        if(Input.GetKey(KeyCode.Space) && stage == 3)
        {
            m3.texture = completed;
            m3T.color = Color.gray;
            
            m1T.rectTransform.position = new Vector2(-9999, -9999);
            m2T.rectTransform.position = new Vector2(-9999, -9999);
            m3T.rectTransform.position = new Vector2(-9999, -9999);

            m1.texture = transparent;
            m2.texture = transparent;
            m3.texture = transparent; 

            bg.texture = alldone;
        }

    }

    /*
    public float distanceTo(Vector3 pos1, Vector3 pos2)
    {
        float distX = pos2.x - pos1.x;
        float distZ = pos2.z - pos1.z;

        float dist = Mathf.Sqrt((distX*distX) + (distZ*distZ));
        return dist;
    }
    */

    public float distanceTo(Vector3 pos)
    {
        float distX = pos.x - player.position.x;
        float distY = pos.y - player.position.z;

        float dist = Mathf.Sqrt((distX*distX) + (distY*distY));
        return dist;
    }
}
