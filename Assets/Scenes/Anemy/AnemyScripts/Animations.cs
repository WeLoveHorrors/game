using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        animator.SetTrigger("Run");
        AnimateAtack();
    }

    // Update is called once per frame
    void Update()
    {
        
        //animator.SetTrigger("Jump");
        //animator.SetTrigger("Land");
        //animator.SetTrigger("Run");
      
        //animator.SetTrigger("Attack1");
       // animator.SetTrigger("Attack2");
        //animator.SetTrigger("Attack1");
    }

    public void AnimateAtack(){
        int rand=Random.Range(1,100);
        if(rand%2==0){
            AnimateJump(rand);
            this.animator.SetTrigger("Attack1");
        }
        if(rand%2==1){
            AnimateJump(rand);
            this.animator.SetTrigger("Attack2");
        }
        Invoke("AnimateAtack",1);
    }

    public void AnimateJump(int rand){
        if(rand<=50){
            this.animator.SetTrigger("Jump");
            this.animator.SetTrigger("Land");
        }
    }
}
