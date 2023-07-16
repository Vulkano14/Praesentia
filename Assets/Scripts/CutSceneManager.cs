using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] PlayableDirector _timeline;
    bool _canIPlayTimeline = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _canIPlayTimeline)
        {
            _canIPlayTimeline = false;
            _timeline.Play();
            
        }
    }
}
