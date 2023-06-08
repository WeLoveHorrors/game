using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string Question;
    public List<Tuple<string, string>> AnswearsAndReplies;

    public Dialogue(string Question, List<Tuple<string, string>> AnswearsAndReplies)
    {
        this.Question = Question;
        this.AnswearsAndReplies = AnswearsAndReplies;
    }
}
