using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeWeapon : MonoBehaviour
{
    public float TimeInteracted;
    public float TimeToDoneInteraction;
    public AudioSource source;
    public AudioClip sound;

    public bool Interacted = false;    
    public Image Interaction;

    public GameObject weaponInstance;
    public GameObject parentInstance;

    public int loadOut;
    
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
                    this.tag = "Untagged";
                    source.PlayOneShot(sound, 0.2f);
                    Interacted = true;

                    GetComponentInParent<Outline>().enabled = false;
                    GetComponent<TitleHandler>().Scaling = false;
                    weaponInstance.transform.localScale = new Vector3(0, 0, 0);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>().SetEnable(loadOut);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>().Equip(loadOut);
                    // GetComponent<TakeWeapon>().enabled = false;
                    Destroy(parentInstance, 1f);

                    // GetComponent<DestroyInstance>().enabled = true;
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