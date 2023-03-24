using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//кто доебется до ошибок в комментариях, тот сдохнет через 5 минут ;)
public class PlayerCam : MonoBehaviour
{
    public float sensX = 0.3f;
    public float sensY = 0.3f;
    public Transform orientation;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Фиксация курсора в пространстве
        Cursor.lockState=CursorLockMode.Locked;
        //Скрытие курсора
        Cursor.visible=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //просцет координат курсора
        float mouseX=Input.GetAxisRaw("Mouse X")*Time.deltaTime*sensX;
        float mouseY=Input.GetAxisRaw("Mouse Y")*Time.deltaTime*sensY;
        xRotation-=mouseY;
        yRotation+=mouseX;
        //ограничение вращения камеры по вертикали 
        xRotation=Mathf.Clamp(xRotation,-90f,90f);
        //изменение поворота камеры в игре
        transform.rotation=Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation=Quaternion.Euler(0,yRotation,0);
    }
}
