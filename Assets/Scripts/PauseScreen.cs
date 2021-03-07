using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public RawImage pauseMenu;

    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.rectTransform.position = new Vector2(-9999, -9999);
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
                pauseMenu.rectTransform.position = new Vector2(960.0f, 540.2f);
                paused = true;
            }
            
        }
        Debug.Log(pauseMenu.rectTransform.position);
    }

    public void Resume()
    {
        pauseMenu.rectTransform.position = new Vector2(-9999, -9999);
        paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
