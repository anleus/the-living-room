using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CD : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable interactable;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider col;

    public void Action()
    {
        var interactor = interactable.firstInteractorSelecting;
        if (interactor != null)
        {
            interactable.interactionManager.SelectExit(interactor, interactable);
        }
        interactable.enabled = false;
        rb.isKinematic = true;
        col.enabled = false;
        transform.rotation = Quaternion.identity;
    }
}
