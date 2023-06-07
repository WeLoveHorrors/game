using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScrollInteraction : MonoBehaviour
{
    public GameObject canvas;

    public bool isTaked=false;
   

    
   

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        canvas.SetActive(false);
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(TakeScroll.isTaked==true)
        {
            OpenScroll();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            TakeScroll.isTaked=false;
            ScrollClosed();
            
        }
    }

    public void OpenScroll()
    {
        canvas.SetActive(true);
    }

    public void ScrollClosed()
    {
        canvas.SetActive(false);
    }
}
