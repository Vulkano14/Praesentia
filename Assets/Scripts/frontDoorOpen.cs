using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontDoorOpen : MonoBehaviour
{
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetBool("doorOpen", true);
        }
    }
}
