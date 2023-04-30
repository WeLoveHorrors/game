using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleGunSystem : MonoBehaviour
{
    Animator m_animator;
    bool shooting, readyToShoot, reloading;
    float bulletsLeft;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    void Awake()
    {
        bulletsLeft = 100;
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
        
        if(shooting) 
        {
            m_animator.SetBool("Shooting", true);
            bulletsLeft = 100;
        }
        else
        {
            m_animator.SetBool("Shooting", false);
        }
    }
}
