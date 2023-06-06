using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseInteraction : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Image crosshair;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isPaused = !isPaused;
            pauseCanvas.SetActive(isPaused);
            Cursor.visible = isPaused;
            Cursor.lockState = isPaused ?  CursorLockMode.None : CursorLockMode.Locked;
            Time.timeScale = isPaused ? 0 : 1;
            crosshair.enabled = !isPaused;
        }
    }
}
