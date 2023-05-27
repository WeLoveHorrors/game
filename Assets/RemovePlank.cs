using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePlank : MonoBehaviour
{
    public float TimeInteracted;
    public float TimeToDoneInteraction;
    public AudioSource source;
    public AudioClip sound;

    public bool Interacted = false;

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
                    source.PlayOneShot(sound, 0.2f);
                    Interacted = true;
                }
            }
            else
            {
                if(TimeInteracted > 0)
                {
                    TimeInteracted -= Time.deltaTime;
                    if(TimeInteracted < 0)
                    {
                        TimeInteracted = 0;
                    }
                }
            }
        }
    }
}