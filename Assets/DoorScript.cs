using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool IsOpen;
    private bool touchingDoor = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.gameObject.tag);
        if(other.gameObject.tag=="Player")
        {
    
           
            touchingDoor = true;

        }
        
        
    }

     private void OnTriggerExit(Collider other)
    {
        touchingDoor=false;
    }

    private void Update()
    {
        if(Input.GetKeyDown("e")&&touchingDoor){

            IsOpen=true;
            GetComponentInParent<Animator>().Play("DoorOpen",0,0);
        }
    }
}