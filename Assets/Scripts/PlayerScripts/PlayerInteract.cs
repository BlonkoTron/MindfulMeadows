using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject interactionMark;
    
    public bool canInteract;
    private bool markActive;
    private Interaction Interactable;

    private void Update()
    {
        if (interactionMark != null)
        {
            if (canInteract && Interactable != null)
            {
                interactionMark.SetActive(true);
       
            }
            else
            {
                interactionMark.SetActive(false);
       
            }
        }
    }

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

            canInteract = false;
        }
    }
}
