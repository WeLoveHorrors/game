using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    private bool isPaused = false;
    public Canvas PauseCanvas;
    public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.sortingOrder = 0;
        PauseCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePause();
        }
    }

    public void HandlePause()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            EnableCanvas();
            Time.timeScale = 0;
            PauseCanvas.sortingOrder = 300;
            // PausePanel.GetComponent<Animator>().Play("PauseShow", 0, 0);
        }
        else 
        {
            PauseCanvas.sortingOrder = 0;
            PausePanel.GetComponent<Animator>().Play("PauseHide", 0, 0);
        }
    }
    
    public void EnableCanvas()
    {
        PauseCanvas.sortingOrder = 300;
        PauseCanvas.gameObject.SetActive(true);
    }
}
