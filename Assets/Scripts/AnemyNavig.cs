using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnemyNavig : MonoBehaviour
{
    //public Transform playertransform;
    public GameObject palyer;
    public float MaxTime=1.0f;
    public float MaxDistance=1.0f;
    float timer=0.0f;
    public Animator animator;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        palyer=GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed",agent.velocity.magnitude);
        
        timer-=Time.deltaTime;
        if(timer<0.0f){
            float sqrdistance=(palyer.transform.position-agent.destination).sqrMagnitude;
            if(sqrdistance>MaxDistance*MaxDistance){
                agent.destination=palyer.transform.position;
            }
            timer=this.MaxTime;
        }
       
        
    }
}
