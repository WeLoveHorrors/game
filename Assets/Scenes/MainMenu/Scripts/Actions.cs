using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject Fading;
    public Canvas canvas;
    
    void Start()
    {
        canvas.sortingOrder = 0;
        Time.timeScale = 1f;
    }
    public void StartPlay()
    {
        canvas.sortingOrder = 10;
        Fading.GetComponent<Animator>().Play("Fading", 0, 0);
    }

}
