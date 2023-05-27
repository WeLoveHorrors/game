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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Interacted)
        {
            if(Input.GetKey(KeyCode.E))
            {
                TimeInteracted += Time.deltaTime;
                if(TimeInteracted > TimeToDoneInteraction)
                {
                    this.gameObject.AddComponent<Rigidbody>();
                    this.tag = "Untagged";
                    source.PlayOneShot(sound, 0.2f);
                    Interacted = true;

                    GetComponent<Outline>().enabled = false;
                    GetComponent<Highlight>()?.ToggleHighlight(false);
                    GetComponent<RemovePlank>().enabled = false;
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