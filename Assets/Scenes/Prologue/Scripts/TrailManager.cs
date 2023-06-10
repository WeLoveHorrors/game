using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrailManager : MonoBehaviour
{
    private float TimeToCreate = 1f;
    public TrailRenderer trail;
    public GameObject trailsPosition;
    private List<TrailRenderer> trails;
    public bool isFlyingVertical = false;

    void Start()
    {
        trails = new List<TrailRenderer>();
    }

    void Update()
    {
        if((TimeToCreate -= Time.deltaTime) <= 0)
        {
            var temptrial = GameObject.Instantiate(trail, trailsPosition.transform.position, Quaternion.identity);
            temptrial.GetComponent<Trail>().isLookingLeft = true;
            trails.Add(temptrial);
            
            var temptrial2 = GameObject.Instantiate(trail, trailsPosition.transform.position, Quaternion.identity);
            temptrial2.GetComponent<Trail>().isLookingLeft = false;
            trails.Add(temptrial2);

            TimeToCreate = Random.Range(0.02f, 0.1f);
        }

        if(trails.Count > 0 && trails.First().gameObject.transform.position.x < -400){
            Destroy(trails.First().gameObject);
            trails.Remove(trails.First());
        }
    }
}
