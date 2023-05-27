using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleHandler : MonoBehaviour
{
    public Canvas canvas;
    private float scale = 0;
    public bool Scaling = false;
    // Start is called before the first frame update
    void Update()
    {
        if(Scaling)
        {
            UpScale();
        }
        else
        {
            DownScale();
        }
    }
    public void UpScale()
    {
        scale += 4f * Time.deltaTime;
        if(scale < 1f)
        {
            canvas.transform.localScale = new Vector3(scale, scale, 1);
        }
        else
        {
            scale = 1f;
            canvas.transform.localScale = new Vector3(scale, scale, 1);
        }
    }

    public void DownScale()
    {
        scale -= 4f * Time.deltaTime;
        if(scale > 0)
        {
            canvas.transform.localScale = new Vector3(scale, scale, 1);
        }
        else
        {
            scale = 0;
            canvas.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
