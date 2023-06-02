using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationMissionTrigger : MonoBehaviour
{
    [SerializeField] GameObject _mission;
    [SerializeField] GameObject _quest1;
    [SerializeField] AudioClip soundEffect;
    [SerializeField] float delay = 8f;
    AudioSource _audioSource;
    bool _hasPlayed = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_hasPlayed)
        {
            _mission.SetActive(true);
            StartCoroutine(ActiveQuest());
            _hasPlayed = true;
        }
    }

    IEnumerator ActiveQuest()
    {
        yield return new WaitForSeconds(delay);
        _audioSource.PlayOneShot(soundEffect);
        yield return new WaitForSeconds(1);
        _quest1.SetActive(true);
        yield return new WaitForSeconds(9);
        Destroy(gameObject);
    }
}
