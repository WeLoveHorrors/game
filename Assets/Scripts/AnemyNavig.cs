using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnemyNavig : MonoBehaviour
{
    public Transform playertransform;
    public float MaxTime=1.0f;
    public float MaxDistance=1.0f;
    float timer=0.0f;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<0.0f){
            float sqrdistance=(playertransform.position-agent.destination).sqrMagnitude;
            if(sqrdistance>MaxDistance*MaxDistance){
                agent.destination=playertransform.position;
            }
            timer=this.MaxTime;
        }
       
        
    }
}
