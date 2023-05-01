using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleGunSystem : MonoBehaviour
{
    public Animator m_animator;
    bool shooting, readyToShoot, reloading;
    float bulletsLeft;
    public float timeBetweenShooting;

    void Awake()
    {
        bulletsLeft = 100;
        Invoke("AllowShoot", 0.1f);
        // Invoke("AllowShoot", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }
    
    private void MyInput()
    {
        shooting = Input.GetKey(KeyCode.Mouse0);
        
        if(readyToShoot && shooting) 
        {
            bulletsLeft = 100;
            m_animator.SetBool("Shooting", shooting);
            readyToShoot = false;
            GetComponentInChildren<DeagleWeaponRecoil>().Fire();
            
            Invoke("ResetShot", timeBetweenShooting); 
        } 
    }
    
    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void AllowShoot()
    {
        readyToShoot = true;
    }
}
