using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueRenderer : MonoBehaviour
{
    public string Text;
    public float BackSize;
    public float LifeTime;

    public bool isDisplaying = false;
    public bool isPlayed = false;
    public float TimeDisplayed;

    public TMP_Text TextCanvas;
    public Image Background;

    private void OnTriggerEnter(Collider other) {
        if(!isPlayed)
        {
            Display();
            isPlayed = true;
        }
    }

    private void Display()
    {
        isDisplaying = true;
        TextCanvas.enabled = true;
        Background.enabled = true;
        TextCanvas.text = Text;
        Background.rectTransform.sizeDelta = new Vector2(BackSize, Background.rectTransform.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDisplaying)
        {
            this.TimeDisplayed += Time.deltaTime;
            if(TimeDisplayed > LifeTime)
            {
                isDisplaying = false;
            }
            
            if(TextCanvas.color.a < 1)
            {
                TextCanvas.color += new Color(0, 0, 0, 2f * Time.deltaTime);
            }
        }
        else
        {
            if(TextCanvas.color.a > 0)
            {
                TextCanvas.color -= new Color(0, 0, 0, 2f * Time.deltaTime);
            }
            else
            {
                TextCanvas.enabled = false;
                Background.enabled = false;
            }
        }
    }
}
