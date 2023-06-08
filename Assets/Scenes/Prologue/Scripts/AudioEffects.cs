using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] effects;

    public void PlayButtonPressed()
    {
        source.PlayOneShot(effects[0], 0.04f);
    }

    public void PlayEmergencyAlarm()
    {
        source.PlayOneShot(effects[0], 0.01f);
    }
}
