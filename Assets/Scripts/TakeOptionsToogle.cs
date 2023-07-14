using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeOptionsToogle : MonoBehaviour
{
    public Toggle isCrosHairEnableToggle;
    public Toggle isFlashlightEnableToggle;
    public Toggle isSpeedEnableToggle;


    void Update()
    {
        GAMEMANAGEROPTION.Instance.optionSelectedCroshair = isCrosHairEnableToggle.isOn;
        GAMEMANAGEROPTION.Instance.optionSelectedFlashlight = isFlashlightEnableToggle.isOn;
        GAMEMANAGEROPTION.Instance.optionSelectedSpeed = isSpeedEnableToggle.isOn;
    }
}
