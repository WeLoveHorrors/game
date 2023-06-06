using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyAttack : MonoBehaviour
{
    public int damage;
    public GameObject player;
    public void OnTriggerEnter(Collider col){
        Atack(col);
        player=GameObject.FindGameObjectWithTag("Player");
    }

    public void Atack(Collider col){
        Debug.Log("Colision Detected");
        if(col.CompareTag("Player")){
            Debug.Log("Player Detected");
            player.GetComponent<PlayerCharacterisictics>().TakeDamage(damage);
        }
    }
}