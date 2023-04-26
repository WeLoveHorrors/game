using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    // Start is called before the first frame update

    public float intensity = 5;
    public float smooth = 10;

    private Quaternion origin_rotation;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public GameObject player;

    public float rotationAmount = 4f;
    public float maxRotationAmount = 5f;
    public float smoothRotation = 12f;

    void Start() 
    {
        origin_rotation = transform.localRotation;
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSway();
    }

    void UpdateSway() { 
        // float t_x_mouse = Input.GetAxis("Mouse X");
        // float t_y_mouse = Input.GetAxis("Mouse Y");

        // Quaternion t_x_adj = Quaternion.AngleAxis(-intensity * t_x_mouse, Vector3.up);
        // Quaternion t_y_adj = Quaternion.AngleAxis(intensity * t_y_mouse, Vector3.right);
        // Quaternion target_rotation = origin_rotation * t_x_adj * t_y_adj;

        // transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * smooth);
        float t_x_mouse = Mathf.Clamp(Input.GetAxis("Mouse X") * 0.02f, -0.06f, 0.06f);
        float t_y_mouse = Mathf.Clamp(Input.GetAxis("Mouse Y") * 0.02f, -0.06f, 0.06f);

        Vector3 finalPosition = new Vector3(t_x_mouse, t_y_mouse, 0);

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            finalPosition + initialPosition,
            Time.deltaTime * 6f
        );
    }
    

    private void TiltSway()
    {
        Vector3 playerVelocity = player.GetComponent<PlayerMovement>().velocity;
        Vector3 localPlayerVelocity = transform.InverseTransformDirection(playerVelocity);
        float tiltY = Mathf.Clamp(localPlayerVelocity.x * rotationAmount, -maxRotationAmount, maxRotationAmount); // tiltY зависит от локальной скорости по x
        float tiltX = Mathf.Clamp(localPlayerVelocity.z * rotationAmount, -maxRotationAmount, maxRotationAmount); // tiltX зависит от локальной скорости по z

        Quaternion finalRotation = Quaternion.Euler(new Vector3(-tiltX, tiltY * 5, tiltY));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * initialRotation, Time.deltaTime * smoothRotation);
    }
}
