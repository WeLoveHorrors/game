using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool IsOpen;
    private bool touchingDoor = false;
    public bool isBlocked = false;
    public GameObject Door;
    public GameObject[] RoomsToShow;
    public GameObject[]spawnPoints;
    public GameObject[]objs;

    public bool Spawn;

    public void OpenFastDoor()
    {
        if (!IsOpen)
        {
            GetComponentInParent<Animator>().Play("DoorShoot1", 0, 0);
            IsOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Room"))
        {
            item.SetActive(false);
        }
        foreach (var item in RoomsToShow)
        {
            item.SetActive(true);
        }
        if(Spawn==true){
            Spawn=false;
            EnemySpawn();
        }
       
    }
    private void Update()
    {

        if (!IsOpen && !isBlocked)
        {
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 thisPos = Door == null ? new Vector3(0, 0, 0) : Door.transform.position;

            if (Vector2.Distance(new Vector2(playerPos.x, playerPos.z), new Vector2(thisPos.x, thisPos.z)) < 8)
            {
                GetComponent<TitleHandler>().Scaling = true;
                if (Input.GetKeyDown("e"))
                {
                    IsOpen = true;
                    GetComponentInParent<Animator>().Play("DoorOpen", 0, 0);
                    GetComponent<TitleHandler>().Scaling = false;
                }
            }
            else
            {
                if (GetComponent<TitleHandler>() != null)
                {
                    GetComponent<TitleHandler>().Scaling = false;
                }
            }
        }
    }

    public void EnemySpawn(){
        for (int i = 0; i < objs.Length; i++)
        {
            GameObject impact = Instantiate(objs[i], spawnPoints[i].transform.position, Quaternion.LookRotation(new Vector3(0f, 0f, 0f)));
        }

    }
}