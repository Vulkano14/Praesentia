using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MyDoorController : MonoBehaviour
{
    [SerializeField] PlayerMovment _playerMovment;

    [SerializeField] Animator _doorAnimation;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _doorOpenClip;
    [SerializeField] AudioClip _doorCloseClip;
    [SerializeField] AudioClip _pianoClip;
    [SerializeField] AudioClip _howIBeSound;

    [SerializeField] AudioClip _twoDocumentPick;

    [SerializeField] GameObject _documentImage;

    [SerializeField] string _nameOpenAnimation = null;
    [SerializeField] string _nameCloseAnimation = null;

    [SerializeField] GameObject _canvasSecondHouse;
    [SerializeField] GameObject _player;
    [SerializeField] Vector3 _positionEnd;
    [SerializeField] Vector3 _twoDocument;

    [SerializeField] PlayableDirector _timeLineDocumentTwo;
    

    bool _doorOpen = false;
    Quaternion _targetQuaterion;

    void Start()
    {
        _targetQuaterion = Quaternion.Euler(0f, 0f, 0f);
    }


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
        _audioSource.PlayOneShot(_doorOpenClip);
        StartCoroutine(PlaySoundEffect());
        _documentImage.SetActive(true);

    }

    public void DocumentPickTwo()
    {
        _audioSource.PlayOneShot(_twoDocumentPick);
        StartCoroutine(PlayTwoDocumentEffect());
    }

    public void DocumentTriger()
    {
        _canvasSecondHouse.SetActive(false); //Enemy
        _documentImage.SetActive(false); //Canvas
        _player.SetActive(false);
        _timeLineDocumentTwo.Play();
    }

    IEnumerator PlaySoundEffect()
    {
        yield return new WaitForSeconds(_doorOpenClip.length);
        _audioSource.PlayOneShot(_doorCloseClip);
        yield return new WaitForSeconds(_doorCloseClip.length);
        _canvasSecondHouse.SetActive(true);
        _doorAnimation.Play(_nameOpenAnimation, 0, 0.0f);
        _audioSource.PlayOneShot(_pianoClip);
        _playerMovment._canMove = false;
        yield return new WaitForSeconds(0.2f);
        _player.transform.position = _positionEnd;
        yield return new WaitForSeconds(0.2f);
        _playerMovment._canMove = true;
        yield return new WaitForSeconds(20f);
        _audioSource.Stop();
        _canvasSecondHouse.SetActive(false);
        _audioSource.PlayOneShot(_howIBeSound);
        yield return new WaitForSeconds(_howIBeSound.length);
        Destroy(gameObject);
    }

    IEnumerator PlayTwoDocumentEffect()
    {
        yield return new WaitForSeconds(_twoDocumentPick.length);
        _timeLineDocumentTwo.Play();
        yield return new WaitForSeconds(55f);
        _playerMovment._canMove = false;
        yield return new WaitForSeconds(0.2f);
        _player.transform.position = _twoDocument;
        yield return new WaitForSeconds(0.2f);
        _player.transform.rotation = _targetQuaterion;
        yield return new WaitForSeconds(0.2f);
        _playerMovment._canMove = true;
    }
}
