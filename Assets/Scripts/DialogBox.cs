using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogBox : MonoBehaviour
{
    [SerializeField] private TMP_Text myTxt;
    [HideInInspector] public bool writeTextDone;

    private void Start()
    {
        ToggleBox(false);
    }
    public void SetNewText(string txt, bool write)
    {
        myTxt.text = txt;
        writeTextDone = false;
        if (write)
        {
            StartCoroutine(WriteText());
        } else
        {
            StopAllCoroutines();
            writeTextDone = true;
        }
    }

    public void ToggleBox(bool isActive)
    {
        if (isActive)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 1);
        } else
        {
            myTxt.text = "";
            GetComponent<Image>().color = new Color(0, 0, 0, 0);

        }
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
