using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string Question;
    public List<string> Answears;

    public Dialogue(string Question, List<string> Answears)
    {
        this.Question = Question;
        this.Answears = Answears;
    }
}
