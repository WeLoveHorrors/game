using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] effects;

    public void PlaySelected()
    {
        source.PlayOneShot(effects[0], 0.02f);
    }
}
