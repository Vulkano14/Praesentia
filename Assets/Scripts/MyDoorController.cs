using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    [SerializeField] Animator _doorAnimation;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _doorOpenClip;
    [SerializeField] AudioClip _doorCloseClip;

    [SerializeField] GameObject _documentImage;

    [SerializeField] string _nameOpenAnimation = null;
    [SerializeField] string _nameCloseAnimation = null;

    bool _doorOpen = false;


    public void PlayAnimation()
    {
        if (!_doorOpen)
        {
            _doorAnimation.Play(_nameOpenAnimation, 0, 0.0f);
            _audioSource.PlayOneShot(_doorOpenClip);
            _doorOpen = true;
        }
        else
        {
            _doorAnimation.Play(_nameCloseAnimation, 0, 0.0f);
            _audioSource.PlayOneShot(_doorCloseClip);
            _doorOpen = false;
        }
    }

    public void DocumentPick()
    {
        Destroy(gameObject, 1f);
        _documentImage.SetActive(true);
    }
}
