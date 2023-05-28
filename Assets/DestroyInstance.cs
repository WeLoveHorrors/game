using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInstance : MonoBehaviour
{
    public float lifeTime = 5f;

    // Update is called once per frame
    void Update()
    {
        this.lifeTime -= 1f * Time.deltaTime;
        if(this.lifeTime <= 0)
        {
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            Destroy(this.gameObject, 4);
        }
    }
}
