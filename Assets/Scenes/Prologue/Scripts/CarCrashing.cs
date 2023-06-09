using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarCrashing : MonoBehaviour
{
    public Image fading;
    public void FadeScreen()
    {
        fading.GetComponent<Animator>().Play("Fading", 0, 0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TestMap");
    }
}
