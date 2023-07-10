using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    [SerializeField] LayerMask pickLayerMask;
    [SerializeField] LayerMask pickLayerMaskDoor;
    [SerializeField] LayerMask pickLayerMaskSwitch;
    [SerializeField] LayerMask pickLayerDocument;

    public Transform playerCameraTransform;

    [SerializeField] GameObject pickUpUI;
    [SerializeField] GameObject doorUI;
    [SerializeField] GameObject switchUI;
    [SerializeField] GameObject pickUpDocumentUI;
    [SerializeField] Animator animator;

    [SerializeField] PlayerMovment _playerMovment;

    [Min(1)]
    public float hitRange = 3;

    public RaycastHit hit;

    bool _isHoldingItem = false;
    [SerializeField] GameObject _flashLightInTable;


    public void Start()
    {
        pickUpUI.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isHoldingItem)
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickLayerMask))
            {
                _flashLightInTable.SetActive(false);
                _playerMovment.firstFlashLight.SetActive(true);
            }
        }

        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.togHighlight(false);
            pickUpUI.SetActive(false);
            doorUI.SetActive(false);
            switchUI.SetActive(false);
            pickUpDocumentUI.SetActive(false);
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.togHighlight(true);
            pickUpUI.SetActive(true);
        }
        else if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickLayerMaskDoor))
        {
            doorUI.SetActive(true);
        }
        else if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickLayerDocument))
        {
            pickUpDocumentUI.SetActive(true);
        }
        else if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickLayerMaskSwitch))
        {
            hit.collider.GetComponent<Highlight>()?.togHighlight(true);
            switchUI.SetActive(true);
        }

    }
}
