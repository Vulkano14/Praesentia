using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public LayerMask pickLayerMask;
    public Transform playerCameraTransform;
    public GameObject pickUpUI;
    
    [Min(1)]
    public float hitRange = 3;

    public RaycastHit hit;

    public void Start()
    {
        pickUpUI.SetActive(false);
    }

    public void Update()
    {
        if(hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.togHighlight(false);
            pickUpUI.SetActive(false);
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.togHighlight(true);
            pickUpUI.SetActive(true);
        }
    }

}
