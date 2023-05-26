using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandle : MonoBehaviour
{
    public bool isAbleToAnim = false;
    public void Inspect()
    {
        if(isAbleToAnim)
        {
            GetComponent<Animator>().Play("Inspect", 0, 0);
            HandleAllow(false);
        }
        // GetComponent<Animator>().Play("ShotgunInspect", 0, 0);
    }

    public void HandleAllow(bool isAble)
    {
        isAbleToAnim = isAble;
    }
}
