using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeTalk : Interaction
{

    [SerializeField] private TMP_Text treeText;
    private string writtenText;

    private protected DialogBox txtBox;

    private void OnEnable()
    {
        writtenText = treeText.text;
        txtBox = GameObject.FindGameObjectWithTag("TreeDialogBox").GetComponent<DialogBox>();
    }

    public override void Interact()
    {
        if (!isInteracting)
        {
            InteractionStart();
        }
        else if (isInteracting)
        {

            InteractionEnd();
        }

    }

    public override void InteractionStart()
    {
        isInteracting = true;
        txtBox.ToggleBox(true);
        txtBox.SetNewText(writtenText, true);
        PlayerMovement.instance.canMove = false;
    }

    public override void InteractionEnd()
    {
        txtBox.SetNewText(writtenText, false);
        txtBox.ToggleBox(false);
        isInteracting = false;
        PlayerMovement.instance.canMove = true;
    }
    public override void InteractionCancel()
    {
        txtBox.SetNewText(writtenText, false);
        txtBox.ToggleBox(false);
        isInteracting = false;
        PlayerMovement.instance.canMove = true;
    }
}
