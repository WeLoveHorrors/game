using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyAttack : MonoBehaviour
{
    public int damage;
    public GameObject player;
    public void OnTriggerEnter(Collider col){
        if(GetComponentInParent<Animations>().distance<=GetComponentInParent<Animations>().MaxAttackDistance){
            Atack(col);
            player=GameObject.FindGameObjectWithTag("Player");
        }
       
    }

    public void Atack(Collider col){
        if(col.CompareTag("Player")&&GetComponentInParent<Anemy>().IsAlive==true){
            Debug.Log("Player Detected");
            player.GetComponent<PlayerCharacterisictics>().TakeDamage(damage);
        }
    }
}