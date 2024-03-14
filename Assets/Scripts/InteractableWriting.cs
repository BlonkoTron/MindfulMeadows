using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWriting : MonoBehaviour
{
    [Multiline]
    [SerializeField] private string prompt;
    private WritingBox myWritingBox;

    private void Start()
    {
        myWritingBox = GameObject.FindGameObjectWithTag("writingbox").GetComponent<WritingBox>();
    }
    public void StartWriting()
    {
        myWritingBox.OpenWritingBox(prompt);
    }
}
