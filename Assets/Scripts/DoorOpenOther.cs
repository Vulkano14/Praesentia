using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenOther : MonoBehaviour
{
    [SerializeField] Animator _animatorOther;
    bool _doorIsOpen = false;

    void Start()
    {
        _animatorOther = GetComponentInParent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !_doorIsOpen)
        {
            _animatorOther.SetBool("door", true);
            _doorIsOpen = true;
        }
        else if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && _doorIsOpen)
        {
            _animatorOther.SetBool("door", false);
            _animatorOther.Play("DoorOpenClose", -1, 1f);
            _doorIsOpen = false;
        }
    }
}
