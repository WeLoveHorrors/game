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
    public GameObject player;

    public float rotationAmount = 4f;
    public float maxRotationAmount = 5f;
    public float smoothRotation = 12f;

    void Start() 
    {
        origin_rotation = transform.localRotation;
        initialPosition = transform.localPosition;
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
        float t_x_mouse = Mathf.Clamp(Input.GetAxis("Mouse X") * 0.08f, -0.2f, 0.2f);
        float t_y_mouse = Mathf.Clamp(Input.GetAxis("Mouse Y") * 0.08f, -0.06f, 0.06f);

        Vector3 finalPosition = new Vector3(t_x_mouse, t_y_mouse, 0);

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            finalPosition + initialPosition,
            Time.deltaTime * 6f
        );
    }
}
