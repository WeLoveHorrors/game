using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer Mixer;

    public void SetLevel(float sliderValue)
    {
        if(sliderValue==0)
        {
            sliderValue = 0.000001f;
        }
        Mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 40);
    }
}
