using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    private bool isPaused = false;
    public Canvas PauseCanvas;
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public GameObject RepliesPanel;
    public List<AudioSource> sources;

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.sortingOrder = 0;
        PauseCanvas.gameObject.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SettingsPanel.activeSelf)
            {
                TurnToPause();
            }
            else
            {
                HandlePause();
            }
        }
    }

    public void TurnSettings()
    {
        SettingsPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void TurnToPause()
    {
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(true);
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

    public void ProceedClicked()
    {
        HandlePause();
    }
    
    public void SettingsClicked()
    {
        
    }
    
    public void MainMenuClicked()
    {
        StartCoroutine(LoadMainMenuScene());
        // SceneManager.LoadScene("MainMenu");
    }
    IEnumerator LoadMainMenuScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
 
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
