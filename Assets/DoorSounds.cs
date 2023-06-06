using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] effects;

    public void PlayDoorOpening()
    {
        source.PlayOneShot(effects[0], 0.018f);
    }

    public void PlayDoorDone()
    {
        source.PlayOneShot(effects[1], 0.35f);
    }
    public void PlayDoorStart()
    {
        source.PlayOneShot(effects[2], 0.18f);
    }
}
