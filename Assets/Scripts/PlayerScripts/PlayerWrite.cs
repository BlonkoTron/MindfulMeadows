using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWrite : Interaction
{
    [Multiline]
    private bool isOpen = false;
    private WritingBox myWritingBox;

    private PlayerInteract playerInteract;
    
    private void Start()
    {
        myWritingBox = GameObject.FindGameObjectWithTag("writingbox").GetComponent<WritingBox>();
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void OnWrite()
    {
        if (!playerInteract.canInteract)
        {   
            if (Inventory.seeds > 0)
            {
                InteractionStart();

                Debug.Log("Jeg er playerWrite og jeg bliver kaldt");

                PlayerMovement.instance.canMove = false;
            }
            
        }
    }

    public override void InteractionStart()
    {
        if (!isOpen)
        {
            myWritingBox.enabled = true;
            myWritingBox.OpenWritingBox();
        }
    }
    public override void InteractionEnd()
    {
        isInteracting = false;
        myInteractionStage = 0;
        myWritingBox.enabled = false;
        PlayerMovement.instance.canMove = true;
    }

}
