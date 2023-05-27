using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingState : MonoBehaviour
{
    public int CountToUnblock = 3;
    public int CurrentCount = 0;
    // Start is called before the first frame update
    public void Unblock()
    {
        CurrentCount++;
        if(CurrentCount >= CountToUnblock)
        {
            GetComponent<DoorScript>().isBlocked = false;
            GetComponent<TitleHandler>().Scaling = true;
        }
    }
}
