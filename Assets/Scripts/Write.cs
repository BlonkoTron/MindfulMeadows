using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Write : Interaction
{
    [Multiline]
    [SerializeField] private string prompt;
    private bool isOpen = false;
    private WritingBox myWritingBox;
    private BadArea badArea=null;

    private void Start()
    {
        myWritingBox = GameObject.FindGameObjectWithTag("writingbox").GetComponent<WritingBox>();
        myWritingBox.myWrite = this.GetComponent<Write>();
        if(GetComponent<BadArea>()!=null)
        {
            badArea = GetComponent<BadArea>();
        }
    }
    public override void InteractionStart()
    {
        if (!isOpen)
        {
            myWritingBox.OpenWritingBox(prompt);
        }
    }
    public override void InteractionEnd()
    {
        isInteracting = false;
        myInteractionStage = 0;
        PlayerMovement.instance.canMove = true;
        if (badArea!=null)
        {
            badArea.treesPlantedHere++;
        }
    }
}
