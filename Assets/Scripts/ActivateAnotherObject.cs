using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnotherObject : MonoBehaviour
{
    [SerializeField] GameObject[] _gameObject;
    
    bool _canIActiveGameObject = true;

    void Start()
    {
        foreach (var item in _gameObject)
        {
            item.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _canIActiveGameObject)
        {
            foreach (var item in _gameObject)
            {
                item.SetActive(true);
            }
        }
    }
}
