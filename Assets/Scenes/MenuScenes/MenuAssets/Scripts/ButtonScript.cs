using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text;
    public Color ColorStandart;
    public Color ColorOnHover;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Enter");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Exit");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        Text.colorGradient = new TMPro.VertexGradient(Color.black, Text.colorGradient.bottomLeft, Text.colorGradient.topRight, Text.colorGradient.bottomRight);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        Text.colorGradient = new TMPro.VertexGradient(ColorStandart, Text.colorGradient.bottomLeft, Text.colorGradient.topRight, Text.colorGradient.bottomRight);
    }
    
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
}
