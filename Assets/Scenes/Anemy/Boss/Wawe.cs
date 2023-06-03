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

    void Start()
    {
        lineRenderer=GetComponent<LineRenderer>();
        lineRenderer.positionCount=PointsCount+1;
    }

    public IEnumerator Blast(){
        float CurentRadius=0f;
        while(CurentRadius<MaxRadius){
            CurentRadius+=Time.deltaTime*Speed;
            Draw(CurentRadius);
            yield return null;
        }
    }

    public void Draw(float CurentRadius){
        float angleBetweenPoints=360f/PointsCount;
        for (int i = 0; i <=PointsCount; i++)
        {
            float angle=i*angleBetweenPoints*Mathf.Deg2Rad;
            Vector3 direction=new Vector3(Mathf.Sin(angle),Mathf.Cos(angle),0f);
            Vector3 position=direction*CurentRadius;
            lineRenderer.SetPosition(i,position);
        }
        lineRenderer.widthMultiplier=Mathf.Lerp(0f,startWidth,1f-CurentRadius/MaxRadius);
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            StartCoroutine(Blast());

        }
    }
}
