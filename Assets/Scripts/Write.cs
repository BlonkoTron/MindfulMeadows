using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Write : Interaction
{
    [Multiline]
    [SerializeField] private string prompt;
    private bool isOpen = false;
    private WritingBox myWritingBox;
    public BadArea badArea;

    private void Start()
    {
        myWritingBox = GameObject.FindGameObjectWithTag("writingbox").GetComponent<WritingBox>();
        myWritingBox.myWrite = this.GetComponent<Write>();

        Debug.Log("bad area added to interaction zone");
        badArea = GetComponent<BadArea>();

        
    }
    public override void InteractionStart()
    {
        if (Inventory.seeds > 0)
        {
            if (!isOpen)
            {
                Debug.Log(gameObject.name + " Write er sej og jeg bliver kaldt");
                CameraController.instance.StopCamera();
                myWritingBox.enabled = true;
                myWritingBox.OpenWritingBox(prompt);
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

        Debug.Log("Interaction End Bliver kaldt");

        if (badArea != null)
        {
            Debug.Log("bad area reduced");
            badArea.treesPlantedHere++;
        }



    }
}
