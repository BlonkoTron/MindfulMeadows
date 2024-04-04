using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class WritingBox : MonoBehaviour
{
    [SerializeField] GameObject textPlantPrefab;
    private string myText;
    [SerializeField] private TMP_Text promptText;
    private TMP_InputField myIputField;
    private Animator anim;
    [HideInInspector] public Write myWrite;
    private SeedCounter seedCounter;
    private float playerOffSet = 0.4f;
    private bool isOpen=false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        myIputField = GetComponentInChildren<TMP_InputField>();
        seedCounter = GameObject.FindGameObjectWithTag("seedCounter").GetComponent<SeedCounter>();
    }
    void OnConfirm(InputValue input)
    {
        if (isOpen)
        {
            SubmitText();
        }
    }
    void OnCancel(InputValue input)
    {
        if (isOpen)
        {
            CancelWriting();
        }
    }

    public void SubmitText()
    {
        myText = myIputField.text;
        if (Inventory.seeds > 0)
        {
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Instantiate(textPlantPrefab, new Vector3(playerPos.x, playerPos.y - playerOffSet, playerPos.z), gameObject.transform.rotation);
            Inventory.seeds--;
            seedCounter.UpdateText();
        }

        myWrite.InteractionEnd();
        CloseWritingBox();
    }
    public void CancelWriting()
    {
        CloseWritingBox();
        myWrite.InteractionCancel();
    }

    public string GetSavedText()
    {
        return myText;
    }

    public void OpenWritingBox()
    {
        myIputField.text = "";
        promptText.text = "";
        anim.SetBool("isActive",true);
        isOpen = true;
    }
    public void OpenWritingBox(string prompt)
    {
        myIputField.text = "";
        promptText.text = prompt;
        anim.SetBool("isActive", true);
        isOpen = true;
    }
    public void CloseWritingBox()
    {   
        myIputField.text = "";
        anim.SetBool("isActive", false);
        isOpen = false;
    }
}
