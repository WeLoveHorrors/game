using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] effects;
    
    public void Play(int id)
    {
        source.PlayOneShot(effects[id], 0.065f);
    }
}
