using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera normalCamera;

    public Transform weapon;
    public Vector3 weaponOrigin;
    public ParticleSystem jumpDust;

    public float movementCounter;
    public float idleCounter;
    public Vector3 targetWeaponBobPosition;
    public Transform dustPosition;

    public float speed = 18f;
    // public float sprintModifier = 2f;
    public float gravity = -42.43f;
    public float jump = 9f;
    public float fallingModifier = 14f;

    public Vector3 velocity;

    public float baseFov;

    bool isAbleToJump;
    bool isFastFalling;

    public AudioSource footsteps;
    public AudioSource runningsteps;

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
            if(isFastFalling)
            {
                ParticleSystem tempJumpDust = Instantiate(jumpDust, dustPosition.transform.position, Quaternion.identity);
                Destroy(tempJumpDust.gameObject, 1f);
            }
            if(!isAbleToJump)
            {
                GetComponent<SoundManager>().Play(5, 0.05f);
            }
            velocity.y = -2f;
            isAbleToJump = true;
            isFastFalling = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float movingForward = Input.GetAxisRaw("Vertical");
        float movingRight = Input.GetAxisRaw("Horizontal");

        bool Sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isSprinting = Sprint;
        
        if((x != 0 || z != 0) && controller.isGrounded)
        {
            if(isSprinting)
            {
                runningsteps.enabled = true;
                footsteps.enabled = false;
            }
            else
            {
                runningsteps.enabled = false;
                footsteps.enabled = true;
            }
        }
        else
        {
            runningsteps.enabled = false;
            footsteps.enabled = false;
        }

        // float t_adjustedSpeed = speed;
        if(movingForward < 0)
        {
            // t_adjustedSpeed *= sprintModifier;
            if(isSprinting)
            {
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 0.97f, Time.deltaTime * 8f);
            }
            else
            {
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 0.95f, Time.deltaTime * 8f);
            }
        }
        else if(movingForward > 0)
        {
            if(isSprinting) 
            {
                
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 2 * 0.51f, Time.deltaTime * 8f);
            }
            else
            {
                normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov * 2 * 0.53f, Time.deltaTime * 8f);
            }
            // t_adjustedSpeed *= sprintModifier;
        }
        else
        {
            normalCamera.fieldOfView = Mathf.Lerp(normalCamera.fieldOfView, baseFov, Time.deltaTime * 8f);
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * (isSprinting ? 1.1f : 0.7f)) * Time.deltaTime);

        if (Input.GetButton("Jump") && isAbleToJump)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            GetComponent<SoundManager>().Play(4, 0.1f);
            isAbleToJump = false;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isAbleToJump && !controller.isGrounded)
        {
            isFastFalling = true;
        }

        if(velocity.y < -10)
        {
            // HeadBob(idleCounter, 0.2f, 0.015f);
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, new Vector3(weaponOrigin.x, Mathf.Sqrt(-velocity.y)/2.8f, weaponOrigin.z), Time.deltaTime * 2f);
        }

        velocity.y += gravity * Time.deltaTime * (isFastFalling ? fallingModifier : 1);
        

        controller.Move(velocity * Time.deltaTime);


        if(movingForward == 0 && movingRight == 0) {
            HeadBob(idleCounter, 0.015f, 0.015f);
            idleCounter += Time.deltaTime;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 2f);

        }
        else
        {
            HeadBob(movementCounter, 0.05f, 0.05f);
            movementCounter += Time.deltaTime * 5f;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 10f);
        }
    }

    void HeadBob(float p_z, float p_x_intensity, float p_y_intensity)
    {
        targetWeaponBobPosition = weaponOrigin + new Vector3(Mathf.Cos(p_z * 2.5f) * p_x_intensity, Mathf.Sin(p_z * 2.5f) * p_y_intensity, Mathf.Sin(p_z) * 0.03f);
    }

    public void ShotJump()
    {
        if(this.gameObject.transform.position.y < 6.5f)
        {
            velocity.y += Mathf.Sqrt(jump * -0.5f * gravity);
            Debug.Log(Camera.main.transform.rotation.x);
        }
    }
}
