using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterisictics : MonoBehaviour
{
    public GameObject canvas;
    public float Health = 100;
    private bool isAlive = true;

    public void TakeDamage(float damage)
    {
        if(this.isAlive)
        {
            this.GetComponentInParent<SoundManager>().Play(3, 1f);
            this.Health -= damage;
            if(this.Health <= 0)
            {
                isAlive = false;
                LaunchDead();
            }
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(15);
        }
    }

    private void LaunchDead()
    {
        canvas.gameObject.SetActive(true);
        canvas.gameObject.GetComponentInParent<Animator>().Play("End Game", 0, 0);
    }
}
