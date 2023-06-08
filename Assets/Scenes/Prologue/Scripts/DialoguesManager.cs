using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguesManager : MonoBehaviour
{
    public List<Dialogue> Dialogues;
    public List<TMP_Text> Answears;
    public TMP_Text Question;

    private int CurrentDialogue = 0;
    void Start()
    {
        Dialogues = new List<Dialogue>();
        Dialogues.Add(new Dialogue("Test scene", new List<string>(){ "Answear 1", "Answear 2", "Answear 3" }));

        int AnswearIndex = 0;
        Answears.ForEach(x=> x.text = Dialogues[CurrentDialogue].Answears[AnswearIndex++]);
        Question.text = Dialogues[CurrentDialogue].Question;
    }
}
