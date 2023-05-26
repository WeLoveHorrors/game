using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandle : MonoBehaviour
{
    public void Inspect()
    {
        GetComponent<Animator>().Play("Inspect", 0, 0);
        // GetComponent<Animator>().Play("ShotgunInspect", 0, 0);
    }
}
