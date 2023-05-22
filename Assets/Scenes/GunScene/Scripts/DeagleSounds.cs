using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip equip;
    public AudioClip readyToShoot;
    public AudioClip equippedFully;

    public void PlayEquip()
    {
        source.PlayOneShot(equip, 0.08f);
    }
    
    public void PlayReadyToShoot()
    {
        source.PlayOneShot(readyToShoot, 0.15f);
    }

    public void PlayEquippedFully()
    {
        source.PlayOneShot(equippedFully, 0.16f);
    }
}
