using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterisictics : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            canvas.gameObject.SetActive(true);
            canvas.gameObject.GetComponentInParent<Animator>().Play("End Game", 0, 0);
        }
    }
}
