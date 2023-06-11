using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CarCrashing : MonoBehaviour
{
    public Image fading;
    public Light alert;
    public GameObject progressPanel;
    public Image progressBar;

    private AsyncOperation asyncLoad;
    

    void Start()
    {
        fading.GetComponent<Animator>().Play("Showing", 0, 0);
    }
    public void FadeScreen()
    {
        fading.GetComponent<Animator>().Play("Fading", 0, 0);
    }
    public void StartGame()
    {
        StartCoroutine("LoadMapScene");
        // SceneManager.LoadScene("TestMap");
    }

    IEnumerator LoadMapScene()
    {
        progressPanel.SetActive(true);
        asyncLoad = SceneManager.LoadSceneAsync("TestMap");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
                progressBar.fillAmount = progress;
            }
            yield return null;
        }
    }

    public void StartAlerting()
    {
        alert.GetComponent<Animator>().Play("BackLightAlert", 0, 0);
    }
}
