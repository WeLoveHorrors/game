using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private float speedX = -3f;
    private float speedZ = 1f;
    void Start() {
        speedX = Random.Range(-250f, -600f);
        bool isLeft = Random.Range(1f, 3f) > 1.5f;
        speedZ = Random.Range(30, 40) * (isLeft ? 1 : -1);
    }
    void Update()
    {
        gameObject.transform.position += new Vector3(speedX, -190f, speedZ) * Time.deltaTime;
        if( gameObject.transform.position.x < -960) Destroy(this.gameObject);
    }
}
