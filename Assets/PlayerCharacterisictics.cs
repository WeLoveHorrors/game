using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCharacterisictics : MonoBehaviour
{
    public GameObject canvas;
    public GameObject damageIndicator;
    public Image healthBar;
    public TMP_Text timeLabel;
    public TMP_Text killsLabel;
    public TMP_Text scoreLabel;
    public TMP_Text healthCount;
    public float Health = 100;
    private bool isAlive = true;
    private float TimeWithoutDamage = 0;

    public float TimeToHeal = 5;
    public float HealForceInitial = 3f;
    private float HealForce = 0.01f;
    private float time = 0;
    private float kills = 0;
    private float score = 0;

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

    //Вызывать этот метод когда игрок убивает врага, передавать счет за тип врага (Либо сам придумай по поводу счета за врага)
    public void AddKill(int score)
    {
        this.kills++;
        this.score += score;
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
        //Прожитое время в игре
        time += Time.deltaTime;

        HandleHealthBar();
        HandleDamageIndicator();
        HandleRegeneration();

        healthCount.SetText($"{(int)(this.Health)}/100");

        if(Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(13);
        }
    }

    private void HandleHealthBar()
    {
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
    }
    private void HandleDamageIndicator()
    {
        if(damageIndicator.GetComponent<Image>().color.a > 0)
        {
            var color = damageIndicator.GetComponent<Image>().color;
            color.a -= 0.5f * Time.deltaTime;
            damageIndicator.GetComponent<Image>().color = color;
        }
    }
    private void HandleRegeneration()
    {
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
                this.HealForce = this.HealForce * 1.003f + this.HealForceInitial;
            }
        }
    }

    private void LaunchDead()
    {
        // Time.timeScale = 0.8f;
        // Camera.main.GetComponent<AudioListener>().enabled = false;
        canvas.gameObject.SetActive(true);
        canvas.gameObject.GetComponentInParent<Animator>().Play("End Game", 0, 0);
        var seconds = (int)(time % 60);
        var displayingseconds = seconds > 10 ? $"{seconds}" : $"0{seconds}";
        killsLabel.SetText(kills.ToString());
        timeLabel.SetText($"{(int)(time/60)}:{displayingseconds}");
        scoreLabel.SetText(score.ToString());
    }
}
