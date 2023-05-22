using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterisictics : MonoBehaviour
{
    public GameObject canvas;
    public GameObject damageIndicator;
    public float Health = 100;
    private bool isAlive = true;

    public void TakeDamage(float damage)
    {
        if(this.isAlive)
        {
            this.GetComponentInParent<SoundManager>().Play(3, 1f);
            var color = damageIndicator.GetComponent<Image>().color;
            color.a = 0.8f;
            damageIndicator.GetComponent<Image>().color = color;
            this.Health -= damage;
            if(this.Health <= 0)
            {
                isAlive = false;
                LaunchDead();
            }
        }
    }

    // Если нужно будет переинициализировать хар-ки игрока после смерти
    public void RestoreCharacter()
    {
        this.Health = 100;
        this.isAlive = true;
        canvas.gameObject.SetActive(false);
    }

    public void Update()
    {
        if(damageIndicator.GetComponent<Image>().color.a > 0)
        {
            var color = damageIndicator.GetComponent<Image>().color;
            color.a -= 0.5f * Time.deltaTime;
            damageIndicator.GetComponent<Image>().color = color;
        }
    }

    private void LaunchDead()
    {
        canvas.gameObject.SetActive(true);
        canvas.gameObject.GetComponentInParent<Animator>().Play("End Game", 0, 0);
    }
}
