using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public string name;
    public GameObject player;
    public Transform BloodPosition;
    public ParticleSystem Blood;
    public ParticleSystem Death;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject anemy;
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
        //skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        this.IsAlive = true;
        if (anemy == null)
        {
            anemy = GameObject.FindGameObjectWithTag("Enemy");
        }


    }
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.F)){
        //     Debug.Log($"{gameObject.transform.forward*5f}");
        //     gameObject.transform.position+=gameObject.transform.forward*5f;

        // }
        BlinckTimer -= Time.deltaTime;
        float Lerp = Mathf.Clamp01(BlinckTimer / BlinckDuration);
        float intensiti = (Lerp * BlinckIntensiti) + 1.0f;
        //skinnedMeshRenderer.material.color = Color.white * intensiti;
    }
    public void TakeDamage(int damage)
    {
        if(CurrentHP<=MaxHP/2){
           StartCoroutine(GetComponentInChildren<Wawe>().WaweBlast());
        }
        if(CurrentHP<=(MaxHP-MaxHP/4)){
            StartCoroutine(GetComponentInChildren<MeteorRain>().RunMeteorRain());
        }
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
        regdoll.AactivRecdoll();
        player.GetComponent<PlayerCharacterisictics>().AddKill(Score);
        Destroy(Bar.gameObject);
        Destroy(this.gameObject,5f);
        ParticleSystem blood = Instantiate(Blood, BloodPosition.transform.position, Quaternion.identity);
        Destroy(blood.gameObject, 1f);
        ParticleSystem death = Instantiate(Death, BloodPosition.transform.position, Quaternion.identity);
        Destroy(death.gameObject, 2f);


    }
}
