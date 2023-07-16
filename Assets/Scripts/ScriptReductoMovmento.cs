using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptReductoMovmento : MonoBehaviour
{
    [SerializeField] PlayerMovment _playerMovment;

    bool _canActivate = true;
    [SerializeField] float _howWaitSeconds;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _canActivate)
        {
            _canActivate = false;
            _playerMovment.moveSpeed = 2f;
            StartCoroutine(WaitSeconds());
        }
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(_howWaitSeconds);
        _playerMovment.moveSpeed = 5f;
    }
}
