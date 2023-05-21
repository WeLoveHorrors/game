using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        if(CurrentHP<0){
            Debug.Log("Chel Pomer");
        }
        else{
            CurrentHP-=damage;
        }

    }
}
