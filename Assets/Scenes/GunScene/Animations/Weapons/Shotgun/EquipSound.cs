using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip equip;
    public AudioClip loaded;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEquip()
    {
        source.PlayOneShot(equip, 0.4f);
    }
    
    public void PlayLoaded()
    {
        source.PlayOneShot(loaded, 0.4f);
    }
}
