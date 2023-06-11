using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandle : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SettingsPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SettingsPanel.activeSelf)
            {
                TurnToMainMenu();
            }
        }
    }

    public void TurnSettings()
    {
        SettingsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void TurnToMainMenu()
    {
        SettingsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
}
