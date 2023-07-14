using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrpitControllBlockArea : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
