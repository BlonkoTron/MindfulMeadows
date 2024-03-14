using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [Multiline]
    [SerializeField] private protected string[] dialogTexts;
    private protected DialogBox txtBox;
    private protected int currentDialogIndex;
    public static bool isTalking=false;
    public static float textSpeed=0.05f;
    [SerializeField] private AudioClip talkingSound;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        txtBox = GameObject.FindGameObjectWithTag("dialogbox").GetComponent<DialogBox>();
    }
    public void Talk()
    {
        if (!isTalking) 
        {
            PlayerMovement.instance.canMove = false;
            isTalking = true;
            txtBox.ToggleBox(true);
            txtBox.SetNewText(dialogTexts[0],true);
            PlayTalkingSound();
        } else
        {
            if (txtBox.writeTextDone)
            {
                NextDialog();
                PlayTalkingSound();
            } else
            {
                txtBox.SetNewText(dialogTexts[currentDialogIndex], false);
            }
        }

    }
    public void NextDialog()
    {
        // check if more dialog is available
        if (currentDialogIndex<dialogTexts.Length-1)
        {
            // set new dialog
            currentDialogIndex++;
            txtBox.SetNewText(dialogTexts[currentDialogIndex],true);
        } else
        {
            // end dialog
            EndDialog();
        }
    }
    public virtual void EndDialog()
    {
        isTalking = false;
        txtBox.ToggleBox(false);
        currentDialogIndex = 0;
        PlayerMovement.instance.canMove = true;   
    }

    private void PlayTalkingSound()
    {
        if (audioSrc!=null && talkingSound!=null)
        {
            audioSrc.PlayOneShot(talkingSound);
        }
    }


}
