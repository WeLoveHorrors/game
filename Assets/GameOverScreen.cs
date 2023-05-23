using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public AudioSource source;
    public AudioClip gameEnd;
    public AudioClip gameEndStart;

    public void PlayGameEnd()
    {
        source.PlayOneShot(gameEnd, 0.5f);
    }    
    public void PlayGameEndStart()
    {
        source.PlayOneShot(gameEndStart, 0.25f);
    }
}
