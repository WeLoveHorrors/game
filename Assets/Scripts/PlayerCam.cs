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
    private Animator cameraShake;
 

    // Start is called before the first frame update
    void Start()
    {
        cameraShake= Camera.main.GetComponent<Animator>();
        //Фиксация курсора в пространстве
        Cursor.lockState=CursorLockMode.Locked;
        //Скрытие курсора
        Cursor.visible=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraShake.SetTrigger("Moving");
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
    }
}
