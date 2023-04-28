using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSway : MonoBehaviour
{
    private Quaternion initialRotation;

    public float rotationAmount = 4f;
    public float maxRotationAmount = 5f;
    public float smoothRotation = 12f;
    public float multiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        TiltSway();
    }
    
    private void TiltSway()
    {
        float movingRight = Input.GetAxisRaw("Horizontal");

        float tiltX = Mathf.Clamp(movingRight * rotationAmount, -maxRotationAmount, maxRotationAmount); // tiltX зависит от локальной скорости по z

        Quaternion finalRotation = Quaternion.Euler(new Vector3(tiltX * 1.65f * multiplier, 0, 0));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * initialRotation, Time.deltaTime * smoothRotation);
    }
}
