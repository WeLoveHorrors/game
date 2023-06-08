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
        int i=0;
        foreach (var item in rigitbodies)
        {
           item.useGravity=false;
        }
        animator=GetComponent<Animator>();
    
    }

    public void TurnOnGraviti(){
        foreach (var item in rigitbodies)
        {
           item.useGravity=true;
        }
    }

    public void DiactivRecdoll(){
        foreach(var rigitbodi in rigitbodies){
            rigitbodi.isKinematic=true;
        }
       this.animator.enabled=false;
    }
    public void AactivRecdoll(){
        foreach(var rigitbodi in rigitbodies){
            rigitbodi.isKinematic=false;
        }
       animator.enabled=false;
    }
}
