using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRunSequence : MonoBehaviour
{
    bool _canActivate = true;
    [SerializeField] GameObject _enemy;
    [SerializeField] RunEnemySequence RunEnemySequence;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;


    void Start()
    {
        _enemy.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _canActivate)
        {
            _audioSource.PlayOneShot(_audioClip);
            Invoke("StopMusic", 11f);
            _canActivate = false;
            _enemy.SetActive(true);
            RunEnemySequence.canRun = true;
        }
    }

    void StopMusic()
    {
        _audioSource.Stop();
    }
}
