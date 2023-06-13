using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private float speedX = -3f;
    private float speedY = -190f;
    private float speedZ = 1f;
    public bool isLookingLeft = false;
    public bool isVertical = false;
    void Start() {
        speedX = Random.Range(-250f, -600f);
        if(!isVertical)
        {
            speedZ = Random.Range(30, 40) * (isLookingLeft ? 1 : -1);
        }
        else
        {
            speedY = -95f;
            speedZ = Random.Range(-30, 30);
        }
    }
    void Update()
    {
        gameObject.transform.position += new Vector3(speedX, speedY, speedZ) * Time.deltaTime;
    }
}
