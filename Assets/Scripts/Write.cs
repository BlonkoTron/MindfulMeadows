using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Write : Interaction
{
    [Multiline]
    [SerializeField] private string prompt;
    private bool isOpen = false;
    private WritingBox myWritingBox;
    private BadArea myBadArea;

    private void Start()
    {
        myBadArea = this.GetComponent<BadArea>();
        myWritingBox = GameObject.FindGameObjectWithTag("writingbox").GetComponent<WritingBox>();
    }
    public override void InteractionStart()
    {
        if (Inventory.seeds > 0)
        {
            if (!isOpen)
            {
                myWritingBox.enabled = true;
                myWritingBox.OpenWritingBox(prompt);
                myWritingBox.myWrite = this.GetComponent<Write>();

                CameraController.instance.StopCamera();

            }
        }
        else
        {
            PlayerMovement.instance.canMove = true;
        }

    }
    public override void InteractionEnd()
    {   

        isInteracting = false;
        myInteractionStage = 0;
        PlayerMovement.instance.canMove = true;
        CameraController.instance.StartCamera();

        myWritingBox.enabled = false;

        if (myBadArea != null)
        {
            Debug.Log("bad area reduced");
            myBadArea.treesPlantedHere++;
        }
    }
    public override void InteractionCancel()
    {
        isInteracting = false;
        myInteractionStage = 0;
        PlayerMovement.instance.canMove = true;

        myWritingBox.enabled = false;
    }
}
