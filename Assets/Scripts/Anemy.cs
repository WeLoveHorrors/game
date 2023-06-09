using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Anemy : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP;
    public int Armor;
    public int Score;
    public bool IsAlive;
    public float BlinckIntensiti;
    public float BlinckDuration;
    float BlinckTimer;
    public GameObject player;
    public Transform BloodPosition;
    public ParticleSystem Blood;
    public ParticleSystem Death;
    public Slider HPbar;
    public GameObject Bar;
    Regdoll regdoll;

    // Start is called before the first frame update
    void Start()
    {
        regdoll=GetComponent<Regdoll>();
        HPbar=GetComponentInChildren<Slider>();
        HPbar.maxValue=MaxHP;
        HPbar.value=MaxHP;
        this.CurrentHP = this.MaxHP;
        player = GameObject.FindGameObjectWithTag("Player");
        this.IsAlive = true;
    }
    // Update is called once per frame
    void Update()
    {
        BlinckTimer -= Time.deltaTime;
        float Lerp = Mathf.Clamp01(BlinckTimer / BlinckDuration);
        float intensiti = (Lerp * BlinckIntensiti) + 1.0f;
    }
    public void TakeDamage(int damage)
    {
        BlinckTimer = BlinckDuration;
        if (this.Armor > 0)
        {
            this.CurrentHP = this.CurrentHP - (damage / 2);
            this.Armor = this.Armor - (damage / 2);
        }
        else
        {
            this.CurrentHP = this.CurrentHP - damage;
        }
        if (this.CurrentHP <= 0)
        {
            if (IsAlive == true)
            {
                IsAlive = false;
                Dead();
            }
        }
        HPbar.value=CurrentHP;
    }

    public void Dead()
    {
        
        regdoll.TurnOnGraviti();
        regdoll.AactivRecdoll();
        GetComponent<NavMeshAgent>().speed=0;
        player.GetComponent<PlayerCharacterisictics>().AddKill(Score);
        Destroy(Bar.gameObject);
        Destroy(this.gameObject,5f);
        ParticleSystem blood = Instantiate(Blood, BloodPosition.transform.position, Quaternion.identity);
        Destroy(blood.gameObject, 1f);
        ParticleSystem death = Instantiate(Death, BloodPosition.transform.position, Quaternion.identity);
        Destroy(death.gameObject, 2f);
    }
}
