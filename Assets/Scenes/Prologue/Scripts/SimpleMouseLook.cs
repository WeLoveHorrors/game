using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseLook : MonoBehaviour
{
    public float mouseSensitivity = 145f;
    public float multiplier = 1f;

    float RotationX = 0f;
    float RotationY = 0f;


     // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        RotationY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * multiplier;
        RotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * multiplier;

        RotationX = Mathf.Clamp(RotationX, -75f, 7f);
        RotationY = Mathf.Clamp(RotationY, 51f, 156f);

        transform.eulerAngles = new Vector3(RotationX, RotationY, 0);
    }
}
