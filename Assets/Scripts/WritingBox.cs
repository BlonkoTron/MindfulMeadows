using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WritingBox : MonoBehaviour
{
    private string myText;
    [SerializeField] private TMP_Text promptText;
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
        promptText.text = "";
        anim.SetBool("isActive",true);
    }
    public void OpenWritingBox(string prompt)
    {
        promptText.text = prompt;
        anim.SetBool("isActive", true);
    }
    public void CloseWritingBox()
    {
        anim.SetBool("isActive", false);
    }
}
