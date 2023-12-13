using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private InputActionReference interactionInput;

    private RaycastHit hit;

    private void Start()
    {
        interactionInput.action.performed += Interact;
    }

    

    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if(hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }
        if(Physics.Raycast(
            playerCameraTransform.position, 
            playerCameraTransform.forward, 
            out hit, 
            hitRange, 
            pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if(hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
    }
}
