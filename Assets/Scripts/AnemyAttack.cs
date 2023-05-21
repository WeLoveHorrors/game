using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyAttack : MonoBehaviour
{

    public int damage;
    public void OnTriggerEnter(Collider col){
        Atack(col);
    }

    public void Atack(Collider col){
    
        if(col.CompareTag("Player")){
            col.GetComponent<Player>().TakeDamage(this.damage);
        }
    }
}