using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGEROPTION : MonoBehaviour
{
    static GAMEMANAGEROPTION _instance;

    public static GAMEMANAGEROPTION Instance
    {
        get { return _instance; }
    }

    public bool optionSelectedCroshair;
    public bool optionSelectedFlashlight;
    public bool optionSelectedSpeed;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
