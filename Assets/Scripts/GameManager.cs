using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayableDirector _timeline;

    void Start()
    {
        _timeline.Play();
    }
}
