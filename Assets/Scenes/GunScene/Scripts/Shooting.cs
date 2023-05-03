using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float range = 100f;
    public GameObject shotOrigin;
    bool isShooting;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    void Shoot(){
        // RaycastHit hit;

        // if(Physics.Raycast(shotOrigin.transform.position, shotOrigin.transform.forward, out hit, range))
        // {
        //     Debug.DrawLine(shotOrigin.transform.position, hit.point, Color.red, 10f);
        // }
    }
}
