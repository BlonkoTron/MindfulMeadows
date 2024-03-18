using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private bool canInteract;
    private Interaction Interactable;

    void OnInteract(InputValue input)
    {
        if (canInteract || Interaction.isInteracting)
        {
            if (Interactable != null)
            {
                PlayerMovement.instance.canMove = false;
                Interactable.Interact();
            }
        }
    }
   

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Interactable"))
        {   

            PlayerMovement.instance.canJump = false;

            Interactable = trigger.GetComponent<Interaction>();

            if (Interactable != null)
            {
                canInteract = true;
            }

        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Interactable"))
        {
            PlayerMovement.instance.canJump = true;

            canInteract = false;
        }
    }
}
