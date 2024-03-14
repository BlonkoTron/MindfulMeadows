using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWriting : MonoBehaviour
{
    [SerializeField] private string prompt;
    private WritingBox myWritingBox;

    private void Start()
    {
        
    }
    public void StartWriting()
    {
        myWritingBox.OpenWritingBox();
    }
}
