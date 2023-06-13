using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MouseSettings : MonoBehaviour
{
    [SerializeField] Slider mouselider;

    float look;
     
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
        Scene scene = SceneManager.GetActiveScene();
        //Camera.main.GetComponent<MouseLook>().mouseSensitivity = mouselider.value * 100;
        if(scene.name=="TestMap")
        {
            
            Camera.main.GetComponent<MouseLook>().mouseSensitivity = mouselider.value * 100;
        }
        //look.getUpdateSend(mouselider.value);
        look=mouselider.value;
        Debug.Log(look);
        Save();
       
    }

    private void Load(){
        Scene scene = SceneManager.GetActiveScene();
        

        if(scene.name=="MainMenu")
        {
            mousesens=PlayerPrefs.GetFloat("mouseSens");
        }
        else if(scene.name=="TestMap")
        {
            mouselider.value=PlayerPrefs.GetFloat("mouseSens");
            Camera.main.GetComponent<MouseLook>().mouseSensitivity = mouselider.value * 100;
        }
        else{
        mouselider.value=PlayerPrefs.GetFloat("mouseSens");
        look=mouselider.value;
        }
        

        //float mouseSensitivity = PlayerPrefs.GetFloat("mouseSens");
        //float rotationAmount = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        
    }

    private void Save(){
        PlayerPrefs.SetFloat("mouseSens", mouselider.value);
       
    }

    
}
