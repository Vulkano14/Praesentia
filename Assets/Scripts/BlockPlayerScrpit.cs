using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayerScrpit : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] GameObject _destroyObject;
    [SerializeField] bool _canDestroyObject = false;

    bool _canIPlayNextAudioClip = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _canIPlayNextAudioClip)
        {
            _audioSource.PlayOneShot(_audioClip);
            _canIPlayNextAudioClip = false;
        }

        if (other.CompareTag("Player") && _canDestroyObject)
        {
            DisableObject();
        }
    }

    void DisableObject()
    {
        Destroy(_destroyObject);
    }
}
