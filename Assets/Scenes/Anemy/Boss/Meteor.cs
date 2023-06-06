using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxRadius;
    private bool TakeDamage;
    private bool Boom;
    ParticleSystem tempJumpDust;
    ParticleSystem tempJumpDust2;
    public ParticleSystem Crcle;
    public ParticleSystem Explo;
    void Start()
    {
        StartCoroutine(Fall());
        tempJumpDust = Instantiate(Crcle,new Vector3(transform.position.x,-11f,transform.position.z), Quaternion.identity);
        TakeDamage=true;
        Boom=true;
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y<=-9.8){
            Blast();
            StartCoroutine(Vzriv()); 
       }
    }


    public IEnumerator Vzriv(){
        yield return new WaitForSeconds(0.1f);
        if(Boom==true){
            Boom=false;
            tempJumpDust2 = Instantiate(Explo,new Vector3(transform.position.x,-11f,transform.position.z), Quaternion.identity);
            Destroy(tempJumpDust2.gameObject,3);
            Destroy(tempJumpDust.gameObject);
            Destroy(this.gameObject);
        }
        
    }
    public IEnumerator Fall(){
        yield return new WaitForSeconds(2f);
        float i=0.5f;
        while(transform.position.y>=-9.8){
            transform.position-=new Vector3(0,i,0);
            yield return new WaitForSeconds(0.02f);
            i*=1.09f;
        }
    }
    public void Blast(){
        Collider[] colliders=Physics.OverlapSphere(transform.position,MaxRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody=colliders[i].attachedRigidbody;
            if(rigidbody){
                PlayerCharacterisictics player=rigidbody.GetComponentInParent<PlayerCharacterisictics>();
                if(player){
                    if(TakeDamage==true){
                        TakeDamage=false;
                        rigidbody.AddExplosionForce(15f,transform.position,MaxRadius);
                        player.TakeDamage(30);
                    }
                }
            }
            
        }
    }

    public void OnDrawGizmos(){
        Gizmos.color=new Color(1f,0f,0f,0.5f);
        Gizmos.DrawWireSphere(transform.position,MaxRadius);
    }

   
}
