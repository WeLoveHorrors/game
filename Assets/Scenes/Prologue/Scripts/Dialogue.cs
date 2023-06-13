using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string Question;
    public List<Tuple<string, string>> AnswearsAndReplies;
    public bool hasAnswears = false;
    public AudioClip voice = null;

    public Dialogue(string Question)
    {
        this.Question = Question;
        this.AnswearsAndReplies = new List<Tuple<string, string>>();
        this.hasAnswears = false;
    }
    public Dialogue(string Question, AudioClip voice)
    {
        this.Question = Question;
        this.hasAnswears = false;
        this.voice = voice;
    }
    public Dialogue(string Question, List<Tuple<string, string>> AnswearsAndReplies)
    {
        this.Question = Question;
        this.AnswearsAndReplies = AnswearsAndReplies;
        this.hasAnswears = true;
    }
    public Dialogue(string Question, List<Tuple<string, string>> AnswearsAndReplies, AudioClip voice)
    {
        this.Question = Question;
        this.AnswearsAndReplies = AnswearsAndReplies;
        this.hasAnswears = true;
        this.voice = voice;
    }

    public void Play(AudioSource source)
    {
        if(this.voice != null)
        {
            source.PlayOneShot(this.voice, 0.2f);
        }
    }
}
