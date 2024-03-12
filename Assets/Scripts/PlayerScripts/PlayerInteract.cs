using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private bool canTalk;
    private Dialog npcDialog;

    void OnInteract(InputValue input)
    {
        if (canTalk)
        {
            if (npcDialog != null)
            {
                npcDialog.Talk();
            }
        }
    }


    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Interactable"))
        {   

            PlayerMovement.instance.canMove = false;

            npcDialog = trigger.GetComponent<Dialog>();

            if (npcDialog != null)
            {
                canTalk = true;
            }

        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Interactable"))
        {
            PlayerMovement.instance.canMove = true;

            canTalk = false;
        }
    }
}
