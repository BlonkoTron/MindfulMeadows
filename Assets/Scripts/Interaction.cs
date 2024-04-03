using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public static bool isInteracting = false;
    private protected int interactionStages;
    private static protected int myInteractionStage=0;
    public virtual void Interact()
    {
        if (!isInteracting)
        {
            InteractionStart();
        }
    }
    public abstract void InteractionStart();

    public abstract void InteractionCancel();
    public abstract void InteractionEnd();
}
