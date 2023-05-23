using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anemy: MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP;
    public int Armor;
    public bool IsAlive;
    public float BlinckIntensiti;
    public float BlinckDuration;
    float BlinckTimer;
    public Transform BloodPosition;
    public ParticleSystem Blood;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject anemy;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        this.CurrentHP=this.MaxHP;
        skinnedMeshRenderer=GetComponentInChildren<SkinnedMeshRenderer>();
        this.IsAlive=true;
        if(anemy==null){
            anemy=GameObject.FindGameObjectWithTag("Enemy");
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.F)){
        //     Debug.Log($"{gameObject.transform.forward*5f}");
        //     gameObject.transform.position+=gameObject.transform.forward*5f;
            
        // }
        BlinckTimer-=Time.deltaTime;
        float Lerp=Mathf.Clamp01(BlinckTimer/BlinckDuration);
        float intensiti=(Lerp*BlinckIntensiti)+1.0f;
        skinnedMeshRenderer.material.color=Color.white*intensiti;
    }
    public void TakeDamage(int damage){
        BlinckTimer=BlinckDuration;
        if(this.Armor>0){
            this.CurrentHP=this.CurrentHP-(damage/2);
            this.Armor=this.Armor-(damage/2);
        }
        else{
            this.CurrentHP=this.CurrentHP-damage;
        }
        if(this.CurrentHP<=0){
            if(IsAlive==true){
                IsAlive=false;
                Dead();
            }
        }
    }

    public void Dead(){
        ParticleSystem blood = Instantiate(Blood, BloodPosition.transform.position, Quaternion.identity);
        Destroy(blood.gameObject, 1f);
        Destroy(this.gameObject);
        
    }
}
