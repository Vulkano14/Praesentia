using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMissionTriger : MonoBehaviour
{
    [SerializeField] AudioClip soundEffect;
    [SerializeField] GameObject _missionDisable;
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
            StartCoroutine(DisableQuest());
            _hasPlayed = true;
        }
    }

    IEnumerator DisableQuest()
    {
        yield return new WaitForSeconds(1);
        _audioSource.PlayOneShot(soundEffect);
        yield return new WaitForSeconds(1);
        _missionDisable.SetActive(false);
        yield return new WaitForSeconds(9);
        Destroy(gameObject);
    }
}
