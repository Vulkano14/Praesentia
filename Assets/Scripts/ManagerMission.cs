using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMission : MonoBehaviour
{
    int i = 0;
    bool isFirstTextMissionInShow = true;

    [SerializeField] GameObject _mission;
    [SerializeField] GameObject[] _quests;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioMissionStart;

    [SerializeField] AudioClip _audioMissionEnd;
    public bool _canIActivateNextMission;

    void Start()
    {
        _mission.SetActive(false);
        _canIActivateNextMission = false;

        foreach (var item in _quests)
        {
            item.SetActive(false);
        }
    }

    public IEnumerator ActivateMission()
    {
        if (isFirstTextMissionInShow)
        {
            _mission.SetActive(true);
            isFirstTextMissionInShow = false;
        }

        _audioSource.PlayOneShot(_audioMissionStart);
        yield return new WaitForSeconds(0.2f);
        _quests[i].SetActive(true);
        i++;

        _canIActivateNextMission = true;
    }

    public IEnumerator DeactivateMission()
    {
        _canIActivateNextMission = false;

        _audioSource.PlayOneShot(_audioMissionEnd);
        yield return new WaitForSeconds(0.8f);
        _quests[i - 1].SetActive(false);
        yield return new WaitForSeconds(2f);
        StartCoroutine(ActivateMission());
    }
}
