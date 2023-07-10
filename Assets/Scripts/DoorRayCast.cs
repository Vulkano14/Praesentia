using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRayCast : MonoBehaviour
{
    public Transform playerCameraTransform;
    [SerializeField] int _rayLenght = 5;
    [SerializeField] LayerMask _layerMaskInteract;

    MyDoorController _raycastedObj;

        string _interactableTag = "InteractibeObject";
    string _interactableTagDocument = "Document";

    [SerializeField] KeyCode _openDoorKey = KeyCode.E;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, _rayLenght))
        {
            if (hit.collider.CompareTag(_interactableTag))
            {
                _raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();

                if (Input.GetKeyDown(_openDoorKey))
                {
                    _raycastedObj.PlayAnimation();
                }
            }
            
            if (hit.collider.CompareTag(_interactableTagDocument))
            {
                _raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();

                if (Input.GetKeyDown(_openDoorKey))
                {
                    _raycastedObj.DocumentPick();
                }
            }
        }
    }
}
