using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WritingBox : MonoBehaviour
{
    private string myText;
    private TMP_InputField myIputField;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        myIputField = GetComponentInChildren<TMP_InputField>();
    }
    public void SubmitText()
    {
        myText = myIputField.text;
    }

    public string GetSavedText()
    {
        return myText;
    }

    public void OpenWritingBox()
    {
        anim.SetBool("isActive",true);
    }
    public void CloseWritingBox()
    {
        anim.SetBool("isActive", false);
    }
}
