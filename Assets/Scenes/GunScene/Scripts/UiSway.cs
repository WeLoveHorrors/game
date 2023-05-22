using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UiSway : MonoBehaviour
{
    public CanvasRenderer[] icons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        icons.ToList().ForEach(x=>x.transform.localPosition += new Vector3(10,0,0));
    }
}
