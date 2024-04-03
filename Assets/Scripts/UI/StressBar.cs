using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    private float currentStress;
    public float oldStress;
    private readonly int maxStress = 100;
    public Animator stressAnimator;
    public Image stressImage;
    public Sprite[] stressSprites;

    private int previousIndex = -1; // Track previous sprite index

    void Start()
    {
        currentStress = 0;
        UpdateStressBar();
    }

    void Update()
    {
        // Example: Increase stress over time
        AddStress(0.01f);
    }

    public void AddStress(float stress)
    {
        float oldStress = currentStress;
        currentStress += stress;
        currentStress = Mathf.Clamp(currentStress, 0, maxStress);

        int currentIndex = Mathf.Clamp((int)(currentStress / maxStress * (stressSprites.Length - 1)), 0, stressSprites.Length - 1);
        int oldIndex = Mathf.Clamp((int)(oldStress / maxStress * (stressSprites.Length - 1)), 0, stressSprites.Length - 1);

        Debug.Log("Stress level changed: " + currentStress);
        Debug.Log("Old stress level: " + oldStress);
        // Check if stress level crossed certain thresholds
        if (currentIndex != oldIndex)
        {
            if (currentStress >= 100 && oldStress < 100)
            {
                PlayAnimation("75_to_100");
            }
            else if (currentStress >= 75 && oldStress < 75)
            {
                PlayAnimation("50_to_75");
            }
            else if (currentStress >= 50 && oldStress < 50)
            {
                PlayAnimation("25_to_50");
            }
            else if (currentStress >= 25 && oldStress < 25)
            {
                PlayAnimation("0_to_25");
            }
            else if (currentStress < 100 && oldStress >= 100)
            {
                PlayAnimation("100_to_75");
            }
            else if (currentStress < 75 && oldStress >= 75)
            {
                PlayAnimation("75_to_50");
            }
            else if (currentStress < 50 && oldStress >= 50)
            {
                PlayAnimation("50_to_25");
            }
            else if (currentStress < 25 && oldStress >= 25)
            {
                PlayAnimation("25_to_0");
            }
        }
    }

    private void PlayAnimation(string animationName)
    {
        if (stressAnimator != null)
        {
            stressAnimator.Play(animationName);
        }
    }

    private void UpdateStressSprites(int index)
    {
        // Update stress sprites based on index
        if (stressImage != null && stressSprites != null && stressSprites.Length > 0)
        {
            stressImage.sprite = stressSprites[index];
        }
    }

    public void UpdateStressBar()
    {
        // Update stress sprites
        int index = Mathf.Clamp((int)(currentStress / maxStress * (stressSprites.Length - 1)), 0, stressSprites.Length - 1);
        if (index != previousIndex)
        {
            previousIndex = index;
            UpdateStressSprites(index);
        }
    }
}