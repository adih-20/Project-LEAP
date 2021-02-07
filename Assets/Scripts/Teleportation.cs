using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform dest;
    public CharacterController charcontroller;
    public GameObject x; 

    void Start()
    {
        x = GameObject.Find("InputField");
        Debug.Log("started");
        x.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            x.SetActive(true);
            charcontroller.enabled = false;
            transform.position = new Vector3(19016.856f, -1013.409f, 13417.899f);
            Debug.Log("attempted teleport");
            charcontroller.enabled = true;
        }
    }
}
