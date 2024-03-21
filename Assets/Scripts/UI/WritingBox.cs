using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WritingBox : MonoBehaviour
{
    [SerializeField] GameObject textPlantPrefab;

    private string myText;
    [SerializeField] private TMP_Text promptText;
    private TMP_InputField myIputField;
    private Animator anim;
    [HideInInspector] public Write myWrite;

    private float playerOffSet = 0.4f;

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
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        Instantiate(textPlantPrefab, new Vector3(playerPos.x, playerPos.y-playerOffSet, playerPos.z), gameObject.transform.rotation);
        anim.SetBool("isActive", false);
        myWrite.InteractionEnd();
    }
}
