using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonInteraction : MonoBehaviour
{
    public GameObject skeleton;
    public AudioSource source;
    public AudioClip sound;
    
    public void ActivateAnimation()
    {
        skeleton.GetComponent<Animator>().Play("Skeleton Used", 0, 0);
        source.PlayOneShot(sound, 0.2f);
    }
}
