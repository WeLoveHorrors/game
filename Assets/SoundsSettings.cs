using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsSettings : MonoBehaviour
{
    [SerializeField] Slider soundslider;
     

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
        else{
            Load();
        }
    }

    public void ChangeVolume(){
        AudioListener.volume=soundslider.value;
        Save();
    }

    private void Load(){
        soundslider.value=PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", soundslider.value);
    }

    
}
