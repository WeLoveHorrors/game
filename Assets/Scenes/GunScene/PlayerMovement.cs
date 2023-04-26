using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera normalCamera;

    public float speed = 12f;
    public float sprintModifier = 2f;
    public float gravity = -29.43f;
    public float jump = 3.4f;

    Vector3 velocity;

    public float baseFov;

    bool isAbleToJump;

    private void Start()
    {
        baseFov = normalCamera.fieldOfView;
        // Camera.main.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            velocity.y = -2f;
            isAbleToJump = true;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float movingForward = Input.GetAxisRaw("Vertical");

        bool Sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isSprinting = Sprint && movingForward > 0;

        float t_adjustedSpeed = speed;
        if (isSprinting)
        {
            t_adjustedSpeed *= sprintModifier;
            normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * sprintModifier * 0.75f, Time.deltaTime * 8f);
        }
        else
        {
            if(movingForward < 0)
            {
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 0.9f, Time.deltaTime * 8f);
            }
            else if(movingForward > 0)
            {
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 1.1f, Time.deltaTime * 8f);
            }
            else
            {
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov, Time.deltaTime * 8f);
            }
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * t_adjustedSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isAbleToJump)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            isAbleToJump = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
