using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandle : MonoBehaviour
{
    public void Inspect()
    {
        
            GetComponent<Animator>().Play("ShotgunInspect", 0, 0);
    }
}
