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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("doorOpen", true);
        }
    }
}
