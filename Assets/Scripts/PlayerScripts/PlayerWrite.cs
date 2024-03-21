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
        myWritingBox.myWrite = this.GetComponent<Write>();

        playerInteract = GetComponent<PlayerInteract>();
    }

    private void OnWrite()
    {
        if (!playerInteract.canInteract)
        {
            InteractionStart();
        }
    }

    public override void InteractionStart()
    {
        if (!isOpen)
        {
            myWritingBox.OpenWritingBox();
        }
    }
    public override void InteractionEnd()
    {
        isInteracting = false;
        myInteractionStage = 0;
        PlayerMovement.instance.canMove = true;
    }
}
