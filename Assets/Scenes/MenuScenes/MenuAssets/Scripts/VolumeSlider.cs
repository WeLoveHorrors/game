using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider Slider;

    public void Start()
    {
        Slider.value = CfgManagement.audioLevel;
        SetAudioLevel(CfgManagement.audioLevel);
    }
    public void SetLevelMixer(float sliderValue)
    {
        if (sliderValue == 0)
        {
            sliderValue = 0.000001f;
        }
        SetAudioLevel(sliderValue);
        CfgManagement.audioLevel = sliderValue;
    }
    private void SetAudioLevel(float value)
    {
        Mixer.SetFloat("MusicVol", Mathf.Log10(value) * 40);
    }
}
