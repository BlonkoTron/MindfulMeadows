using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [Multiline]
    [SerializeField] private protected string[] dialogTexts;
    [SerializeField] private protected DialogBox txtBox;
    private protected int currentDialogIndex;
    private protected static bool isTalking=false;
    public static float textSpeed=0.05f;


    public void Talk()
    {
        if (!isTalking) 
        {
            isTalking = true;
            txtBox.ToggleBox(true);
            txtBox.SetNewText(dialogTexts[0]);
        } else
        {
            NextDialog();
        }

    }
    public void NextDialog()
    {
        // check if more dialog is available
        if (currentDialogIndex<dialogTexts.Length-1)
        {
            // set new dialog
            currentDialogIndex++;
            txtBox.SetNewText(dialogTexts[currentDialogIndex]);
        } else
        {
            // end dialog
            EndDialog();
        }
    }
    private void EndDialog()
    {
        isTalking = false;
        txtBox.ToggleBox(false);
        currentDialogIndex = 0;
    }


}
