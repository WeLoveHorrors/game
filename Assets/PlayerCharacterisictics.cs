using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCharacterisictics : MonoBehaviour
{
    public GameObject canvas;
    public GameObject damageIndicator;
    public Image healthBarBack;
    public Image healthBarEmpty;
    public Image healthBar;
    public Image healthBarMedium;
    public Image healthBarLow;
    public Image healthBarProgress;
    public TMP_Text timeLabel;
    public TMP_Text killsLabel;
    public TMP_Text scoreLabel;
    public TMP_Text healthCount;
    public float Health = 100;
    private bool isAlive = true;
    private float TimeWithoutDamage = 0;
    private float TimeAfterDamage = 0;
    private float CurrentProgress = 100;

    public float TimeToHeal = 5;
    public float HealForceInitial = 3f;
    private float HealForce = 0.01f;
    private float time = 0;
    private float kills = 0;
    private float score = 0;

    public Image dialogueBackground;
    public TMP_Text dialogueText;
    private void Start() {
        // healthBarBack.enabled = false;
        // healthBarEmpty.enabled = false;
        // healthBar.enabled = false;
        // healthBarMedium.enabled = false;
        // healthBarLow.enabled = false;
        // healthBarProgress.enabled = false;
        // healthCount.enabled = false;

        dialogueText.color = new Color(1, 1, 1, 0);
        dialogueBackground.enabled = false;
        dialogueText.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        if(this.isAlive)
        {
            this.healthCount.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            this.TimeAfterDamage = 0;
            this.TimeWithoutDamage = 0;
            this.HealForce = 1;
            this.GetComponentInParent<SoundManager>().Play(3, 0.4f);
            var color = damageIndicator.GetComponent<Image>().color;
            color.a = 1f;
            damageIndicator.GetComponent<Image>().color = color;
            this.Health -= damage;
            if(this.Health <= 0)
            {
                this.Health = 0;
                isAlive = false;
                LaunchDead();
            }
            healthBar.fillAmount = this.Health / 100;
            healthBarMedium.fillAmount = this.Health / 100;
            healthBarLow.fillAmount = this.Health / 100;
        }
    }

    //Викликати коли гравець вбиває ворога
    public void AddKill(int score)
    {
        this.kills++;
        this.score += score;
    }

    // Якщо потрібно буде переініціалізувати характеристики гравця після смерті
    public void RestoreCharacter()
    {
        this.Health = 100;
        this.isAlive = true;
        canvas.gameObject.SetActive(false);
    }

    public void Update()
    {
        //Час у грі
        time += Time.deltaTime;

        HandleHealthBar();
        HandleDamageIndicator();
        HandleRegeneration();
        HandleProgress();

        healthCount.SetText($"{(int)(this.Health)}/100");

        if(Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(13);
        }
    }

    private void HandleHealthBar()
    {
        if(this.Health < 55)
        {
            healthBar.color = new Color(1, 1, 1, 0);
            healthBarLow.color = new Color(1, 1, 1, 1);
            healthBarMedium.color = new Color(1, 1, 1, (Health - 15) / 55);
        }
        else
        {
            healthBar.color = new Color(1, 1, 1, (Health - 45) / 55);
            healthBarMedium.color = new Color(1, 1, 1, 0);
            healthBarLow.color = new Color(1, 1, 1, 0);
        }
    }
    private void HandleDamageIndicator()
    {
        if(damageIndicator.GetComponent<Image>().color.a > 0)
        {
            var color = damageIndicator.GetComponent<Image>().color;
            color.a -= 0.7f * Time.deltaTime;
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
                healthBarMedium.fillAmount = this.Health / 100;
                healthBarLow.fillAmount = this.Health / 100;
                this.HealForce = this.HealForce * 1.003f + this.HealForceInitial;
                healthBarProgress.fillAmount = this.Health / 100;
                CurrentProgress = this.Health;
            }
        }
    }

    private void HandleProgress()
    {
        if(this.HealForce < 100)
        {
            this.TimeAfterDamage += Time.deltaTime;
            if(this.TimeAfterDamage > 0.6f)
            {
                if(CurrentProgress > this.Health)
                {
                    float normalizedHealth = this.Health / 100;
                    float normalizedProgress = this.CurrentProgress / 100;
                    float deltaProgress = 4f * (normalizedProgress - normalizedHealth);
                    
                    CurrentProgress -= deltaProgress;

                    if(CurrentProgress - Health <= 0.01f)
                    {
                        CurrentProgress = Health;
                    }
                }

                healthBarProgress.fillAmount = this.CurrentProgress / 100;
            }
            
            if(this.healthCount.transform.localScale.x > 0.3995417f)
            {
                this.healthCount.transform.localScale -= new Vector3(0.004f, 0.004f, 0.004f);
            }
            else
            {
                this.healthCount.transform.localScale = new Vector3(0.3995417f, 0.3995417f, 0.3995417f);
            }
        }
    }

    private void LaunchDead()
    {
        canvas.gameObject.SetActive(true);
        canvas.gameObject.GetComponentInParent<Animator>().Play("End Game", 0, 0);
        var seconds = (int)(time % 60);
        var displayingseconds = seconds > 10 ? $"{seconds}" : $"0{seconds}";
        killsLabel.SetText(kills.ToString());
        timeLabel.SetText($"{(int)(time/60)}:{displayingseconds}");
        scoreLabel.SetText(score.ToString());
    }
}