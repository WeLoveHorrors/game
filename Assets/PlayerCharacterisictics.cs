using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterisictics : MonoBehaviour
{
    public GameObject canvas;
    public GameObject damageIndicator;
    public Image healthBar;
    public float Health = 100;
    private bool isAlive = true;
    private float TimeWithoutDamage = 0;

    public float TimeToHeal = 5;
    public float HealForceInitial = 3f;
    private float HealForce = 0.01f;

    public void TakeDamage(float damage)
    {
        if(this.isAlive)
        {
            this.TimeWithoutDamage = 0;
            this.HealForce = 1;
            this.GetComponentInParent<SoundManager>().Play(3, 0.4f);
            var color = damageIndicator.GetComponent<Image>().color;
            color.a = 0.8f;
            damageIndicator.GetComponent<Image>().color = color;
            this.Health -= damage;
            if(this.Health <= 0)
            {
                this.Health = 0;
                isAlive = false;
                LaunchDead();
            }
            healthBar.fillAmount = this.Health / 100;
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

        if(this.Health < 30)
        {
            healthBar.color = new Color(1, 0.121f, 1, 1);
        }
        else if(this.Health < 55)
        {
            healthBar.color = new Color(1, 0.6159f, 0.2594f, 1);
        }
        else
        {
            healthBar.color = new Color(0.6451917f, 0.9433962f, 1, 1);
        }

        if(this.Health < 100)
        {
            this.TimeWithoutDamage += Time.deltaTime;
            if(this.TimeWithoutDamage > this.TimeToHeal)
            {
                this.Health += this.HealForce * Time.deltaTime;
                if(this.Health > 100) 
                {
                    this.Health = 100;
                    this.HealForce = 1;
                    this.TimeWithoutDamage = 0;
                }
                healthBar.fillAmount = this.Health / 100;
                this.HealForce = this.HealForce * 1.005f + this.HealForceInitial;
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(13);
        }
    }

    private void LaunchDead()
    {
        // Time.timeScale = 0.8f;
        canvas.gameObject.SetActive(true);
        canvas.gameObject.GetComponentInParent<Animator>().Play("End Game", 0, 0);
    }
}
