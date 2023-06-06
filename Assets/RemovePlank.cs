using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemovePlank : MonoBehaviour
{
    public float TimeInteracted;
    public float TimeToDoneInteraction;
    public AudioSource source;
    public AudioClip sound;

    public bool Interacted = false;    
    public Image Interaction;
    public GameObject WhatToBlock;
    public AudioSource woodCrack;
    
    // Update is called once per frame
    void Update()
    {
        if(!Interacted && enabled)
        {
            if(Input.GetKey(KeyCode.E))
            {
                TimeInteracted += Time.deltaTime;
                woodCrack.enabled = true;

                if(TimeInteracted > TimeToDoneInteraction)
                {
                    this.gameObject.AddComponent<Rigidbody>();
                    this.tag = "Untagged";
                    source.PlayOneShot(sound, 0.2f);
                    Interacted = true;

                    GetComponent<Outline>().enabled = false;
                    GetComponent<Highlight>()?.ToggleHighlight(false);
                    GetComponent<RemovePlank>().enabled = false;
                    GetComponent<TitleHandler>().Scaling = false;

                    WhatToBlock.GetComponent<BlockingState>().Unblock();
                    GetComponent<DestroyInstance>().enabled = true;
                    woodCrack.enabled = false;
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

                woodCrack.enabled = false;
            }

            Interaction.fillAmount = TimeInteracted / TimeToDoneInteraction;
        }
    }
}