using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regdoll : MonoBehaviour
{
    Rigidbody[] rigitbodies;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigitbodies=GetComponentsInChildren<Rigidbody>();
        DiactivRecdoll();
        animator=GetComponent<Animator>();
    
    }

    public void DiactivRecdoll(){
        foreach(var rigitbodi in rigitbodies){
            rigitbodi.isKinematic=true;
        }
       // this.animator.enabled=false;
    }
    public void AactivRecdoll(){
        foreach(var rigitbodi in rigitbodies){
            rigitbodi.isKinematic=false;
        }
       // animator.enabled=false;
    }
}
