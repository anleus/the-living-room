using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

public class RemoteController : MonoBehaviour
{
    public delegate void SendCommandController(RemoteCommand command);
    public static event SendCommandController OnSendCommandController;

    [Header("References")]
    [SerializeField] private XRGrabInteractable controllerInteractable;
    [SerializeField] private List<XRSimpleInteractable> buttonInteractables;
    [SerializeField] private List<RemoteCommand> buttonCommands;

    public void SetHoldStatus(bool state)
    {
        buttonInteractables.ForEach(interactable => interactable.enabled = state);
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Hola" + args.interactableObject);
    }

    public void OnActivated(ActivateEventArgs args)
    {
        IdentifyCollider(args.interactableObject);
    }

    private void IdentifyCollider(IXRActivateInteractable interactable)
    {
        int interactableIndex = buttonInteractables.FindIndex(button => button.transform == interactable.transform);
        if (interactableIndex != -1) {
            OnSendCommandController?.Invoke(buttonCommands[interactableIndex]);
        } 
    }
}
