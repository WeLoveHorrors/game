using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeScroll : MonoBehaviour
{
    public float TimeInteracted;
    public float TimeToDoneInteraction;
    public AudioSource source;
    public AudioClip sound;

    public bool Interacted = false;    
    public Image Interaction;

    public GameObject ScrollInstance;

    public int numberofScroll;
    public GameObject parentInstance;

    public static bool isTaked = false;

    
    
    // Update is called once per frame
    void Update()
    {
        

        if(!Interacted && enabled)
        {
            if(Input.GetKey(KeyCode.E))
            {
                TimeInteracted += Time.deltaTime;
                if(TimeInteracted > TimeToDoneInteraction)
                {
                    //this.tag = "Untagged";
                    source.PlayOneShot(sound, 0.2f);
                    Interacted = true;

                    //ScrollInstance.transform.localScale = new Vector3(0, 0, 0);
                    
                    // GetComponent<TakeWeapon>().enabled = false;
                    Destroy(parentInstance, 1f);
                    isTaked=true;
                    
                    
                    

                   
                }
            }
            else
            {
                if(TimeInteracted > 0)
                {
                    TimeInteracted -= Time.deltaTime * 3;
                    if(TimeInteracted < 0)
                    {
                        TimeInteracted = 0;
                    }
                }
            }

            Interaction.fillAmount = TimeInteracted / TimeToDoneInteraction;
        }

        
    }

     

    
}