using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffObject : MonoBehaviour
{
    [SerializeField] GameObject _blockFloor;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _blockFloor.SetActive(false);
        }
    }
}
