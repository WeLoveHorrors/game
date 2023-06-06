using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundUpdater : MonoBehaviour
{
    public Image background;

    // Update is called once per frame
    void Update()
    {
        if(background.color.a > 0)
        {
            background.color -= new Color(0,0,0, 0.35f * Time.deltaTime);
        }
        else
        {
            Destroy(background, 1);
        }
    }
}
