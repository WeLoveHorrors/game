using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseInteraction : MonoBehaviour
{
    public GameObject canvas;
    public GameObject pauseCanvas;
    public GameObject settingsCanvas;
    public Image crosshair;
    //public TMP_Text mouseSensitivity;
    public Slider mouseSensitivitySlider;

    public AudioSource source;

    public AudioSource volume;
    public AudioClip buttonClicked;

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("mouseSens"))
        {
            PlayerPrefs.SetFloat("mouseSens",0.7f);
            Load();
        }
        else{
            Load();
        }
        isPaused = false;
        canvas.SetActive(false);
        pauseCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ?  CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = isPaused ? 0 : 1;
        crosshair.enabled = !isPaused;

       // mouseSensitivity.text = (Camera.main.GetComponent<MouseLook>().mouseSensitivity / 100f).ToString();


    }

    private void Awake() {
        mouseSensitivitySlider.value = Camera.main.GetComponent<MouseLook>().mouseSensitivity / 100f;   
        //mouseSensitivity.text = (Camera.main.GetComponent<MouseLook>().mouseSensitivity / 100f).ToString();
    }

    public void CheckClick(){
        Debug.Log("Clicked");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(canvas.activeSelf == true && pauseCanvas.activeSelf == false)
            {
                BackToPauseMenu();
            }
            else
            {
                TogglePause();
            }
        }
    }

    public void UpdateSensitivity(float sensitivity)
    {
        Camera.main.GetComponent<MouseLook>().mouseSensitivity = sensitivity * 100;

        Save();
       
    }

    private void Load(){
        mouseSensitivitySlider.value=PlayerPrefs.GetFloat("mouseSens");
        Camera.main.GetComponent<MouseLook>().mouseSensitivity = mouseSensitivitySlider.value * 100;
    }

    private void Save(){
        PlayerPrefs.SetFloat("mouseSens", mouseSensitivitySlider.value);
    }

    public void UpdateSounds(float volume)
    {
        //Camera.main.GetComponent<MouseLook>().mouseSensitivity = sensitivity * 100;
        //mouseSensitivity.text = sensitivity.ToString("0.00");
        
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        canvas.SetActive(isPaused);
        pauseCanvas.SetActive(isPaused);
        settingsCanvas.SetActive(false);
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ?  CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = isPaused ? 0 : 1;
        crosshair.enabled = !isPaused;

        source.PlayOneShot(buttonClicked, 0.05f);
    }

    public void SettingsClicked()
    {
        settingsCanvas.SetActive(true);
        pauseCanvas.SetActive(false);

        source.PlayOneShot(buttonClicked, 0.05f);
    }
    public void MainMenuClicked()
    {
        source.PlayOneShot(buttonClicked, 0.05f);

        SceneManager.LoadScene("StartMenu",LoadSceneMode.Single);
    }


    public void BackToPauseMenu()
    {
        pauseCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        
        source.PlayOneShot(buttonClicked, 0.05f);
    }
}
