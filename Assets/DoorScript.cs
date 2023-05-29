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

    public void OpenFastDoor()
    {
        if(!IsOpen)
        {
            GetComponentInParent<Animator>().Play("DoorShoot1",0,0);
            IsOpen=true;
        }
    }


    private void Update()
    {
        // if(Input.GetKeyDown("e"))
        // {
        //     Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //     Vector3 thisPos = Door.transform.position;

        //     Debug.Log($"Player {playerPos}");
        //     Debug.Log($"This {thisPos}");

        //     Debug.Log(Vector2.Distance(new Vector2(playerPos.x, playerPos.z), new Vector2(thisPos.x, thisPos.z)));
        // }

        if(!IsOpen && !isBlocked)
        {
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 thisPos = Door == null ? new Vector3(0,0,0) : Door.transform.position;

            if(Vector2.Distance(new Vector2(playerPos.x, playerPos.z), new Vector2(thisPos.x, thisPos.z)) < 8)
            {
                GetComponent<TitleHandler>().Scaling = true;
                if(Input.GetKeyDown("e") )
                {
                    IsOpen=true;
                    GetComponentInParent<Animator>().Play("DoorOpen", 0, 0);
                    GetComponent<TitleHandler>().Scaling = false;
                }
            }
            else
            {
                if(GetComponent<TitleHandler>() != null)
                {
                    GetComponent<TitleHandler>().Scaling = false;
                }
            }
        }
    }
}