using UnityEngine;
using UnityEngine.UI;

public class MouseSensSlider : MonoBehaviour
{
    public Slider Slider;

    public void Start()
    {
        Slider.value = CfgManagement.mouseSensitivity;
    }
    public void SetLevelSens(float sliderValue)
    {
        if(sliderValue==0)
        { 
            sliderValue = 0.000001f;
        }
        CfgManagement.mouseSensitivity = sliderValue;
    }
}
