using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.gameObject.tag);
        if(other.gameObject.tag=="Player")
        {
           
            
            GetComponent<Animator>().SetBool("isOpen",true);
        }
        
        
    }
}
