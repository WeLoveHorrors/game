using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseInteraction : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject pauseCanvas;
    public GameObject settingsCanvas;
    public Image crosshair;
    public TMP_Text mouseSensitivity;

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseCanvas.SetActive(isPaused);
        settingsCanvas.SetActive(false);
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ?  CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = isPaused ? 0 : 1;
        crosshair.enabled = !isPaused;

        mouseSensitivity.text = (Camera.main.GetComponent<MouseLook>().mouseSensitivity / 100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseCanvas.SetActive(isPaused);
        settingsCanvas.SetActive(false);
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ?  CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = isPaused ? 0 : 1;
        crosshair.enabled = !isPaused;
    }

    public void SettingsClicked()
    {
        settingsCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }
    public void MainMenuClicked()
    {
        SceneManager.LoadScene("StartMenu",LoadSceneMode.Single);
    }
}
