using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   public Transform playerTransform;
    public float leanAngle = 10f;
    public float maxLeanAmount = 1f;
    public float leanSpeed = 2f;
    public float maxTiltAngle = 15f;
    public float tiltSpeed = 2f;

    private Vector3 lastPlayerPosition;
    private Vector3 movementDirection;
    private float leanAmount;
    private float tiltAmount;

    void Start()
    {
        lastPlayerPosition = playerTransform.position;
    }

    void Update()
    {
        
        movementDirection = playerTransform.position - lastPlayerPosition;
        float distance = movementDirection.magnitude;

        
        float leanX = Mathf.Clamp(movementDirection.x * leanAngle, -maxLeanAmount, maxLeanAmount);
        float leanZ = Mathf.Clamp(movementDirection.z * leanAngle, -maxLeanAmount, maxLeanAmount);
        leanAmount = Mathf.Lerp(leanAmount, Mathf.Abs(leanX + leanZ), Time.deltaTime * leanSpeed);

        
        float targetTiltAngle = Mathf.Clamp(movementDirection.z * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        tiltAmount = Mathf.Lerp(tiltAmount, targetTiltAngle, Time.deltaTime * tiltSpeed);

       
        Quaternion leanRotation = Quaternion.Euler(tiltAmount, 1, -leanX);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, leanRotation, leanAmount);

        
        lastPlayerPosition = playerTransform.position;
    }

   
}

