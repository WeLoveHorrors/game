using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastOpen : MonoBehaviour
{
    public void OpenFastDoorWithShotgun()
    {
        GetComponentInChildren<DoorScript>().OpenFastDoor();
    }
}
