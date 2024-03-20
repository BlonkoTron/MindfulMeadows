using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    private WritingBox writingBox;
    private TextMeshPro TMP;
    private string enteredText;

    private void Awake()
    {
        TMP = GetComponent<TextMeshPro>();
        writingBox = GameObject.FindGameObjectWithTag("writingbox").GetComponent<WritingBox>();
    }

    private void Start()
    {
        enteredText = writingBox.GetSavedText();
        if (enteredText != null )
        {
            ChangeText(enteredText);
        }
        else
        {
            ChangeText("you done goofed");
        }
        
    }

    public void ChangeText(string inputText)
    {
        if (TMP != null)
        {
            TMP.text = inputText;
        }
    }


}
