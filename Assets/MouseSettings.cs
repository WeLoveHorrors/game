using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MouseSettings : MonoBehaviour
{
    [SerializeField] Slider mouselider;

    MouseLook look;
     
     float mousesens;

    void Start()
    {
        
        if(!PlayerPrefs.HasKey("mouseSens"))
        {
            PlayerPrefs.SetFloat("mouseSens",0.7f);
            Load();
        }
        else{
            Load();
        }
    }

     public void UpdateSensitivity()
    {
        //Camera.main.GetComponent<MouseLook>().mouseSensitivity = mouselider.value * 100;
        look.getUpdateSend(mouselider.value);
        Save();
       
    }

    private void Load(){
        Scene scene = SceneManager.GetActiveScene();
        

        if(scene.Name=="MainMenu")
        {
            mousesens=PlayerPrefs.GetFloat("mouseSens");
        }
        else{
        mouselider.value=PlayerPrefs.GetFloat("mouseSens");
        look.getUpdateSend(mouselider.value);
        }
        

        //float mouseSensitivity = PlayerPrefs.GetFloat("mouseSens");
        //float rotationAmount = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        
    }

    private void Save(){
        PlayerPrefs.SetFloat("mouseSens", mouselider.value);
    }

    
}
