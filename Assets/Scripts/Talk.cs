using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : Interaction
{
    [Multiline]
    [SerializeField] private protected string[] dialogTexts;
    private protected DialogBox txtBox;
    public static float textSpeed=0.05f;

    private void Start()
    {
        interactionStages = dialogTexts.Length;
        txtBox = GameObject.FindGameObjectWithTag("dialogbox").GetComponent<DialogBox>();
    }
    public override void Interact()
    {
        if (!isInteracting)
        {
            InteractionStart();
        } else
        {
            if (txtBox.writeTextDone)
            {
                NextDialog();
            }
            else
            {
                txtBox.SetNewText(dialogTexts[myInteractionStage], false);
            }
        }
    }
    public override void InteractionStart()
    {
        isInteracting = true;
        txtBox.ToggleBox(true);
        txtBox.SetNewText(dialogTexts[0], true);
    }
    public void NextDialog()
    {
        // check if more dialog is available
        if (myInteractionStage<dialogTexts.Length-1)
        {
            // set new dialog
            myInteractionStage++;
            txtBox.SetNewText(dialogTexts[myInteractionStage],true);
        } else
        {
            // end dialog
            InteractionEnd();
        }
    }
    public override void InteractionEnd()
    {
        PlayerMovement.instance.canMove = true;
        isInteracting = false;
        myInteractionStage = 0;
        txtBox.ToggleBox(false);
    }
    public override void InteractionCancel()
    {
        PlayerMovement.instance.canMove = true;
        isInteracting = false;
        myInteractionStage = 0;
        txtBox.ToggleBox(false);
    }
}
