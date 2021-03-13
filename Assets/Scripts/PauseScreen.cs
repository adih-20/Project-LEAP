using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public RawImage pauseMenu;
	public GameObject obj;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
		 gameObject.GetComponent<CanvasRenderer>().cull = true;
		 foreach (CanvasRenderer r in gameObject.GetComponentsInChildren<CanvasRenderer>())
				r.cull = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
				gameObject.GetComponent<CanvasRenderer>().cull = false;
				foreach (CanvasRenderer r in gameObject.GetComponentsInChildren<CanvasRenderer>())
					r.cull = false;
				paused = true;
            }
            
        }
    }

    public void Resume()
    {
		gameObject.GetComponent<CanvasRenderer>().cull = true;
		foreach (CanvasRenderer r in gameObject.GetComponentsInChildren<CanvasRenderer>())
				r.cull = true;
        paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
