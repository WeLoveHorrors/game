using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   Camera cam;
    public float shakeIntensity = 0.1f; // интенсивность тряски
    public float shakeSpeed = 0.4f; // скорость тряски

    private Vector3 initialPosition; // начальное положение камеры
    

    void Start()
    {
        cam=GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Shake();
        }
        if(Input.GetKey(KeyCode.S))
        {
            Shake();
        }
        if(Input.GetKey(KeyCode.A))
        {
            Shake();
        }
        if(Input.GetKey(KeyCode.D))
        {
            Shake();
        }
        
    }

    void Shake(){
        float shakeAmount = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 ? shakeIntensity * 2 : shakeIntensity; 

        Vector3 shake = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * shakeAmount; 

        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + shake, Time.deltaTime * shakeSpeed);
    }

   
}

