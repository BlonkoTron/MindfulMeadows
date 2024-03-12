using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private TMP_Text myTxt;
    public bool writeTextDone;

    public void SetNewText(string txt)
    {
        myTxt.text = txt;
        writeTextDone = false;
        StartCoroutine(WriteText());
        
    }

    public void ToggleBox(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    private IEnumerator WriteText()
    {
        int textLength = myTxt.text.Length; // get length of chosen text
        string myText = myTxt.text; // make a copy of the text to manipulate for later
        myTxt.text = myText.Insert(0, "<alpha=#00>"); // set text invisible by inserting <alpha> attribute into start of the text
        int i = 0;
        // insert the <alpha> attribute to a new place each time, revealing a new character of the text, until everything is visible.
        while (i <= textLength)
        {
            myTxt.text = myText.Insert(i, "<alpha=#00>");
            yield return new WaitForSeconds(Dialog.textSpeed); // delay
            i++;
        }
        writeTextDone = true;
    }
}
