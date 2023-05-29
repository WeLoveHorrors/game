using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastOpen : MonoBehaviour
{
    public bool Enabled = true;
    public void OpenFastDoorWithShotgun()
    {
        if(Enabled)
        {
            GetComponentInChildren<DoorScript>().OpenFastDoor();
        }
    }
}
