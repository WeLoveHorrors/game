using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wawe : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public int PointsCount;
    public float MaxRadius;
    public float Speed;
    public float startWidth;
    public bool TakeDamage;
    public ParticleSystem Atention;

    void Start()
    {
        lineRenderer=GetComponentInParent<LineRenderer>();
        lineRenderer.positionCount=PointsCount+1;
        TakeDamage=true;
        //StartCoroutine(WaweBlast());
    }

    public IEnumerator Blast(){
        float CurentRadius=0f;
        while(CurentRadius<MaxRadius){
            CurentRadius+=Time.deltaTime*Speed;
            Draw(CurentRadius);
            Damage(CurentRadius);
            yield return null;
        }
    }
    public void Damage(float CurentRadius){
        Collider[] colliders=Physics.OverlapSphere(transform.position,CurentRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody=colliders[i].attachedRigidbody;
            if(rigidbody){
                PlayerCharacterisictics player=rigidbody.GetComponentInParent<PlayerCharacterisictics>();
                if(player){
                    if(GameObject.FindGameObjectWithTag("Player").transform.position.y<=2){
                        if(TakeDamage==true){
                            TakeDamage=false;
                            player.TakeDamage(30);
                        }
                    }
                }
            }
            
        }
    }

    public void Draw(float CurentRadius){
        float angleBetweenPoints=360f/PointsCount;
        for (int i = 0; i <=PointsCount; i++)
        {
            float angle=i*angleBetweenPoints*Mathf.Deg2Rad;
            Vector3 direction=new Vector3(Mathf.Sin(angle),Mathf.Cos(angle),0f);
            Vector3 position=direction*CurentRadius;
            lineRenderer.SetPosition(i,position/1.5f);
        }
        lineRenderer.widthMultiplier=Mathf.Lerp(0f,startWidth,1f-CurentRadius/MaxRadius);
    }

    public void Update(){
        // if(Input.GetKeyDown(KeyCode.E)){
        //     StartCoroutine(Blast());
        //     TakeDamage=true;
        // }
    }

    public IEnumerator WaweBlast(){
        while(true){
            // ParticleSystem atention = Instantiate(Atention, this.transform.position, Quaternion.identity);
            // Destroy(atention.gameObject, 5f);
            yield return new WaitForSeconds(5f);
            StartCoroutine(Blast());
            TakeDamage=true;
            yield return new WaitForSeconds(15f);
        }
    }

    // public void OnDrawGizmos(){
    //     Gizmos.color=new Color(1f,0f,0f,0.5f);
    //     Gizmos.DrawWireSphere(transform.position,MaxRadius);
    // }
}
