using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThing : MonoBehaviour
{
    public float lifeTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime -= 1f * Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(this.gameObject.GetComponent<CapsuleCollider>());
            Destroy(this.gameObject, 1);
        }

        // this.gameObject.transform.position += direction * speed * Time.deltaTime;
        Vector3 direction = this.gameObject.transform.rotation * Vector3.forward;
        this.gameObject.GetComponent<Rigidbody>().AddForce(direction * 200);
    }
}
