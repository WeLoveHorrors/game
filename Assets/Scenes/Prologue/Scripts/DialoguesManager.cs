using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DialoguesManager : MonoBehaviour
{
    public List<Dialogue> Dialogues;
    public List<TMP_Text> Answears;
    public TMP_Text Question;
    public GameObject AnswearsPanel;

    public bool isTextRendered = false;

    
    private float TextIndex = 0;
    private int CurrentDialogue = 0;
    private string TextGoal = "";
    private bool needToReply = false;
    private bool isFading = false;

    void Start()
    {
        Dialogues = new List<Dialogue>();
        Dialogues.Add(new Dialogue("Марті.."));
        Dialogues.Add(new Dialogue("Марті, ти мене чуєш?"));
        Dialogues.Add(new Dialogue("В нас проблеми, Марті", new List<Tuple<string, string>>(){ new Tuple<string, string>("Що коїться, Док?", "Я ледве встиг тебе врятувати, як в нас пройшла сутичка з тими бандитами."), new Tuple<string, string>("Де ми?", "На нас напали, бо я вкрав пляшечку львівського. Тебе вирубили, я ледве встиг нас з тобою врятувати.."), new Tuple<string, string>("Куди ми летимо?", "В цьому і проблема.. Коли ми намагалися втікти, то пошкодили наш пристрій для подорожів у часі..") }));
        
        SetDialogues();
        AnswearsPanel.SetActive(false);
    }

    void Update()
    {
        if(!isTextRendered)
        {
            if(TextIndex < TextGoal.Length)
            {
                Question.text = TextGoal.Substring(0, (int)(TextIndex+= 15f * Time.deltaTime));
            }
            else
            {
                isTextRendered = true;

                if(needToReply && Dialogues[CurrentDialogue].hasAnswears)
                {
                    Invoke("UnlockPanel", 1.5f);
                }
                else
                {
                    Invoke("RunNext", 2f);
                }
            }
        }
        
        if(isFading)
        {
            if(Question.color.a > 0)
            {
                Question.color -= new Color(0,0,0, 10f * Time.deltaTime);
            }
            else
            {
                Question.gameObject.SetActive(false);
            }
        }
    }

    private void SetDialogues()
    {
        TextIndex = 0;
        if(Dialogues[CurrentDialogue].hasAnswears)
        {
            int AnswearIndex = 0;
            Answears.ForEach(x=> x.text = Dialogues[CurrentDialogue].AnswearsAndReplies[AnswearIndex++].Item1);
            needToReply = true;
        }
        Question.text = "";
        TextGoal = Dialogues[CurrentDialogue].Question;
    }

    private void UnlockPanel()
    {
        AnswearsPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void RunNext()
    {
        if(CurrentDialogue < Dialogues.Count - 1)
        {
            TextIndex = 0;
            CurrentDialogue++;

            isTextRendered = false;
            // needToReply = true;
            SetDialogues();
        }
        else
        {
            isFading = true;
        }
    }

    public void AnswearToQuestion(int number)
    {
        needToReply = false;
        TextIndex = 0;
        AnswearsPanel.SetActive(false);
        isTextRendered = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        TextGoal = Dialogues[CurrentDialogue].AnswearsAndReplies[number].Item2;
        // Invoke("RunNext", 4f);
        // Question.text = 
        // Question.text
    }
}
