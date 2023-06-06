using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenuActions : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    public TMP_Text mouseSensitivity;
    public Slider mouseSensitivitySlider;
    private float sensitivity = 1.45f;

    private void Awake() {
        mouseSensitivity.text = this.sensitivity.ToString();
        mouseSensitivitySlider.value = this.sensitivity;
    }

    public void GoToSettings()
    {
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
    
    public void GoToMainMenu()
    {
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }
    
    public void PlayPrologue()
    {
        SceneManager.LoadScene("TestMap",LoadSceneMode.Single);
    }
    
    public void UpdateSensitivity(float sensitivity)
    {
        this.sensitivity = sensitivity;
        mouseSensitivity.text = this.sensitivity.ToString("0.00");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
