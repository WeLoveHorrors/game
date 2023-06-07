using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRain : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Boss;
    public GameObject Meteor;
    public int MeteorCount;
    public int Radius;
    public int Height;

    void Start()
    {
        Boss=GameObject.FindGameObjectWithTag("Boss").transform;
        //StartCoroutine(RunMeteorRain());
    }

    public void Spawn()
    {
        int rand=Random.Range(1,200);
        GameObject impact = Instantiate(Meteor, new Vector3(GetRandomPos()+(Boss.position.x-Radius/2),Height,GetRandomPos()+(Boss.position.z-Radius/2)), Quaternion.LookRotation(new Vector3(0f, 0f, 0f)));
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Y)){
        //     for (int i = 0; i < MeteorCount; i++)
        //     {
        //         Spawn();
        //     }
        // }
    }

    public IEnumerator RunMeteorRain(){
        while(true){
            for (int i = 0; i < MeteorCount; i++)
            {
                Spawn();
            }
            yield return new WaitForSeconds(10f);
        }
     
    }

    public int GetRandomPos()
    {
        return Random.Range(1,Radius);
    }
}