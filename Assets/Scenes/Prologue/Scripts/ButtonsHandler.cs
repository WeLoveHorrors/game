using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    public GameObject[] Buttons;
    public void HandleButton1()
    {
        Buttons[0].GetComponent<Animator>().Play("Button1", 0, 0);
    }
    public void HandleButton2()
    {
        Buttons[1].GetComponent<Animator>().Play("Button3", 0, 0);
    }
    public void HandleButton3()
    {
        Buttons[2].GetComponent<Animator>().Play("Button4", 0, 0);
    }
    public void HandleButton4()
    {
        Buttons[3].GetComponent<Animator>().Play("Button5", 0, 0);
    }
    public void HandleButton5()
    {
        Buttons[4].GetComponent<Animator>().Play("Button6", 0, 0);
    }
    public void HandleButton6()
    {
        Buttons[5].GetComponent<Animator>().Play("Button7", 0, 0);
    }
}
