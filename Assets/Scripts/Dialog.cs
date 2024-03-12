using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    [Multiline]
    [SerializeField] private string[] dialogTexts;
    [SerializeField] private DialogBox txtBox;

    private int currentDialogIndex;
    public void StartDialog()
    {

    }
    public void NextDialog()
    {
        currentDialogIndex++;
    }


}
