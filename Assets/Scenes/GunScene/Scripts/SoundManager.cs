using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] effects;
    
    public void Play(int id, float Volume)
    {
        source.PlayOneShot(effects[id], Volume);
    }

    void Start() {
        // source.PlayOneShot(songs[0]);    
    }
}
