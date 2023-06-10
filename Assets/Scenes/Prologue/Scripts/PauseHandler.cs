using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    private bool isPaused = false;
    public Canvas PauseCanvas;
    public GameObject PausePanel;
    public GameObject RepliesPanel;
    public List<AudioSource> sources;

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.sortingOrder = 0;
        PauseCanvas.gameObject.SetActive(false);
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
            PauseCanvas.gameObject.SetActive(true);
            PausePanel.GetComponent<Animator>().Play("PauseShow", 0, 0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GetComponentInChildren<DialoguesManager>().sources.ForEach(x=>x.enabled = false);
        }
        else 
        {
            GetComponentInChildren<DialoguesManager>().sources.ForEach(x=>x.enabled = true);
            PausePanel.GetComponent<Animator>().Play("PauseHide", 0, 0);
            if(!RepliesPanel.activeSelf)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    
    public void EnableCanvas()
    {
        PauseCanvas.sortingOrder = 300;
        PauseCanvas.gameObject.SetActive(true);
    }
}
