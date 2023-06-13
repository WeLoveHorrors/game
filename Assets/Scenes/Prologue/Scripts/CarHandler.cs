using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    public GameObject Car;
    public AudioSource source;
    public AudioClip effect;
    public List<AudioSource> sourcesToDisable;
    public void HandleCar()
    {
        Car.GetComponent<Animator>().Play("Car crashing", 0, 0);
    }

    public void PlayAlarm()
    {
        source.PlayOneShot(effect, 0.3f);
    }
    
    public void DisableSounds()
    {
        sourcesToDisable.ForEach(x=>x.enabled = false);
    }
}
