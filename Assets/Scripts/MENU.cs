using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MENU : MonoBehaviour
{
    [SerializeField] GameObject _canvasTW;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Option()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TW()
    {
        StartCoroutine(TimeShow());
    }

    IEnumerator TimeShow()
    {
        _canvasTW.SetActive(true);
        yield return new WaitForSeconds(8f);
        _canvasTW.SetActive(false);
    }
}