using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera normalCamera;

    public Transform weapon;
    public Vector3 weaponOrigin;
    public float movementCounter;
    public float idleCounter;
    public Vector3 targetWeaponBobPosition;

    public float speed = 24f;
    public float sprintModifier = 2f;
    public float gravity = -29.43f;
    public float jump = 6f;

    public Vector3 velocity;

    public float baseFov;

    bool isAbleToJump;

    private void Start()
    {
        baseFov = normalCamera.fieldOfView;
        weaponOrigin = weapon.localPosition;
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
        float movingRight = Input.GetAxisRaw("Horizontal");

        bool Sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isSprinting = Sprint;

        float t_adjustedSpeed = speed;
        if (isSprinting)
        {
            if(movingForward < 0)
            {
                t_adjustedSpeed *= sprintModifier;
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 0.85f, Time.deltaTime * 8f);
            }
            else
            {
                t_adjustedSpeed *= sprintModifier;
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * sprintModifier * 0.55f, Time.deltaTime * 8f);
            }
        }
        else
        {
            if(movingForward < 0)
            {
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 0.95f, Time.deltaTime * 8f);
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


        if(movingForward == 0 && movingRight == 0) {
            HeadBob(idleCounter, 0.015f, 0.015f);
            idleCounter += Time.deltaTime;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 2f);
        }
        else if(Sprint)
        {
            HeadBob(movementCounter, 0.05f, 0.05f);
            movementCounter += Time.deltaTime * 5f;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 10f);
        }
        else
        {
            HeadBob(movementCounter, 0.035f, 0.035f);
            movementCounter += Time.deltaTime * 3f;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 6f);
        }
    }

    void HeadBob(float p_z, float p_x_intensity, float p_y_intensity)
    {
        targetWeaponBobPosition = weaponOrigin + new Vector3(Mathf.Cos(p_z * 2) * p_x_intensity, Mathf.Sin(p_z * 2) * p_y_intensity, 0);
    }
}
