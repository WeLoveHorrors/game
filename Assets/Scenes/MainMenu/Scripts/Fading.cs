using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour
{
    public void LoadPrologue()
    {
        SceneManager.LoadScene("CatScene");
    }
}
