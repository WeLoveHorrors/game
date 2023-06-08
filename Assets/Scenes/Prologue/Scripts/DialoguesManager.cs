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
    private bool isQuestion = false;
    void Start()
    {
        Dialogues = new List<Dialogue>();
        Dialogues.Add(new Dialogue("Test dialogue 1", new List<Tuple<string, string>>(){ new Tuple<string, string>("Answear 1", "asd"), new Tuple<string, string>("Answear 2", "qwe"), new Tuple<string, string>("Answear 3", "qwe") }));
        Dialogues.Add(new Dialogue("Test dialogue 1", new List<Tuple<string, string>>(){ new Tuple<string, string>("Answear 1 qweqweasd", "asdzxcg s"), new Tuple<string, string>("Answear 2 dgdfgvbcbbt", "qweytryrt"), new Tuple<string, string>("Answear 3 aasqweetr", "qwejhg  hjg") }));
        
        SetDialogues();
        AnswearsPanel.SetActive(false);
    }

    void Update()
    {
        if(!isTextRendered)
        {
            if(TextIndex < TextGoal.Length)
            {
                Question.text = TextGoal.Substring(0, (int)(TextIndex+= 10f * Time.deltaTime));
            }
            else
            {
                isTextRendered = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                if(isQuestion)
                {
                    Invoke("UnlockPanel", 1.5f);
                }
            }
        }
    }

    private void SetDialogues()
    {
        int AnswearIndex = 0;
        TextIndex = 0;
        Answears.ForEach(x=> x.text = Dialogues[CurrentDialogue].AnswearsAndReplies[AnswearIndex++].Item1);
        // Question.text = Dialogues[CurrentDialogue].Question;
        isQuestion = true;
        Question.text = "";
        TextGoal = Dialogues[CurrentDialogue].Question;
    }

    private void UnlockPanel()
    {
        AnswearsPanel.SetActive(true);
    }

    private void RunNext()
    {
        TextIndex = 0;
        CurrentDialogue++;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isTextRendered = false;
        isQuestion = true;
        SetDialogues();
    }

    public void AnswearToQuestion(int number)
    {
        isQuestion = false;
        TextIndex = 0;
        AnswearsPanel.SetActive(false);
        isTextRendered = false;

        TextGoal = Dialogues[CurrentDialogue].AnswearsAndReplies[number].Item2;
        Invoke("RunNext", 4f);
        // Question.text = 
        // Question.text
    }
}
