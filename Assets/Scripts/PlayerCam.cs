using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//кто доебется до ошибок в комментариях, тот сдохнет через 5 минут ;)
public class PlayerCam : MonoBehaviour
{
    private float sensX = CfgManagement.mouseSensitivity;
    private float sensY = CfgManagement.mouseSensitivity;
    public Transform orientation;
    float xRotation;
    float yRotation;

    public float leanAngle = 10f;
    public float maxLeanAmount = 1f;
    public float leanSpeed = 2f;
    public float maxTiltAngle = 15f;
    public float tiltSpeed = 2f;

    private Vector3 lastPlayerPosition;
    private Vector3 movementDirection;
    private float leanAmount;
    private float tiltAmount;


    // Start is called before the first frame update
    void Start()
    {
        if(sensX == 0)
        {
            sensX = 0.4f;
        }
        if(sensY == 0)
        {
            sensY = 0.4f;
        }
        //Фиксация курсора в пространстве
        Cursor.lockState=CursorLockMode.Locked;
        //Скрытие курсора
        Cursor.visible=false;
        lastPlayerPosition = orientation.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //просцет координат курсора
        float mouseX=Input.GetAxisRaw("Mouse X")*Time.deltaTime*sensX * 1000;
        float mouseY=Input.GetAxisRaw("Mouse Y")*Time.deltaTime*sensY * 1000;
        xRotation-=mouseY;
        yRotation+=mouseX;
        //ограничение вращения камеры по вертикали 
        xRotation=Mathf.Clamp(xRotation,-90f,90f);
        //изменение поворота камеры в игре
        transform.rotation=Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation=Quaternion.Euler(0,yRotation,0);

        movementDirection = orientation.position - lastPlayerPosition;
        float distance = movementDirection.magnitude;

        
        float leanX = Mathf.Clamp(movementDirection.x * leanAngle, -maxLeanAmount, maxLeanAmount);
        float leanZ = Mathf.Clamp(movementDirection.z * leanAngle, -maxLeanAmount, maxLeanAmount);
        leanAmount = Mathf.Lerp(leanAmount, Mathf.Abs(leanX + leanZ), Time.deltaTime * leanSpeed);

        
        float targetTiltAngle = Mathf.Clamp(movementDirection.z * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        tiltAmount = Mathf.Lerp(tiltAmount, targetTiltAngle, Time.deltaTime * tiltSpeed);

       
        Quaternion leanRotation = Quaternion.Euler(tiltAmount, 1, -leanX);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, leanRotation, leanAmount);

        
        lastPlayerPosition = orientation.position;
        
    }
}
