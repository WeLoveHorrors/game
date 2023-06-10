using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    private float TimeToCreate = 1f;
    public TrailRenderer trail;
    public GameObject trailsPosition;

    void Update()
    {
        if((TimeToCreate -= Time.deltaTime) <= 0)
        {
            var TempTrail = GameObject.Instantiate(trail, trailsPosition.transform.position, Quaternion.identity);
            TimeToCreate = Random.Range(0.1f, 0.3f);
        }
    }
}
