using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressAnimationController : StateMachineBehaviour
{
    private StressBar stressBar;

    public bool IsHighStress;
    public bool IsMediumStress;
    public bool IsLowStress;
    public bool IsMinStress;
    public bool IsMaxStress;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get the StressBar component attached to the same GameObject
        stressBar = animator.GetComponent<StressBar>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Access the current stress level from the StressBar script    
        if (stressBar != null)
        {
            float currentStress = stressBar.GetCurrentStress();

            // Set the float parameter in the animator
            animator.SetFloat("CurrentStress", currentStress);
        }
    }
}