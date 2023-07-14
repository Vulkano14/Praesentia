using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayableDirector _timeline;
    [SerializeField] GameObject _blockArea;

    void Start()
    {
        _blockArea.SetActive(false);
        _timeline.Play();
        StartCoroutine(ActivateBlockArea());
    }

    IEnumerator ActivateBlockArea()
    {
        yield return new WaitForSeconds(50f);
        _blockArea.SetActive(true);
    }
}
