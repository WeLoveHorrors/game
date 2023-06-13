using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyAttack : MonoBehaviour
{
    public int damage;
    public GameObject player;


    public void Start(){
        player=GameObject.FindGameObjectWithTag("Player");
    }
    public void OnTriggerEnter(Collider col){
        if(GetComponentInParent<Animations>().distance<=GetComponentInParent<Animations>().MaxAttackDistance){
            Atack(col);
        }
    
       
    }

    public void Atack(Collider col){
        Debug.Log(col.tag);
        if(col.CompareTag("Player")&&GetComponentInParent<Anemy>().IsAlive==true){
            player.GetComponent<PlayerCharacterisictics>().TakeDamage(damage);
        }
    }
}