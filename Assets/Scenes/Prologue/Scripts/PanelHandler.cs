using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : MonoBehaviour
{
    public Canvas PauseCanvas;
    public void DisableCanvas()
    {
        PauseCanvas.sortingOrder = 0;
        PauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
