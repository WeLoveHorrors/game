using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TestMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void StartGame()
    {
        Debug.Log("start game...");
        SceneManager.LoadScene("TestScene");
    }
    public void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }

    public void Settings()
    {
        Debug.Log("enter setting");
        SceneManager.LoadScene("Settings");
    }
}
