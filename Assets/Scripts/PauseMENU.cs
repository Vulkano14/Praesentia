using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMENU : MonoBehaviour
{
    [SerializeField] GameObject _canvasPauseMENU;

    bool _isPause = false;

    void Start()
    {
        _canvasPauseMENU.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _canvasPauseMENU.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            if (_isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _isPause = false;
        _canvasPauseMENU.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        _isPause = true;
    }
}
