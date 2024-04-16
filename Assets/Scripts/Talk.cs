using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : Interaction
{
    [Multiline]
    [SerializeField] private protected string[] dialogTexts;
    private protected DialogBox txtBox;
    public static float textSpeed=0.05f;

    private AudioManager instance;

    private void Start()
    {
        interactionStages = dialogTexts.Length;
        txtBox = GameObject.FindGameObjectWithTag("dialogbox").GetComponent<DialogBox>();
        instance = FindObjectOfType<AudioManager>();
    }
    public override void Interact()
    {
        if (!isInteracting)
        {
            Debug.Log("Attempting to start interaction...");
            InteractionStart();
        } else
        {
            if (txtBox.writeTextDone)
            {
                instance.Stop("npcvoice");
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
        Debug.Log("Starting interaction...");
        isInteracting = true;
        if (instance != null)
        {
            instance.Play("npcvoice", false);
            Debug.Log("Playing voice...");
        }
        else
        {
            Debug.LogWarning("No Audio Manager assigned to NPC?");
        }

        txtBox.ToggleBox(true);
        txtBox.SetNewText(dialogTexts[0], true);
        Debug.Log("Text set...");
    }
    public void NextDialog()
    {
        // check if more dialog is available
        if (myInteractionStage < dialogTexts.Length-1)
        {
            // set new dialog
            myInteractionStage++;
            instance.Play("npcvoice", false);
            txtBox.SetNewText(dialogTexts[myInteractionStage],true);
        } else
        {
            // end dialog
            InteractionEnd();
        }
    }
    public override void InteractionEnd()
    {
        instance.Stop("npcvoice");
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
