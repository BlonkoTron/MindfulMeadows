using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StressAttempt : MonoBehaviour
{
    private float currentStress;
    public float oldStress;
    private readonly int maxStress = 100;
    public Animator stressAnimator;
    public Image stressImage;
    public Sprite[] stressSprites;

    void Start()
    {
        currentStress = 0;
        UpdateStressBar();
    }

    void Update()
    {
        // Example: Increase stress over time
        AddStress(0.1f);
    }

    public void AddStress(float stress)
    {
        oldStress = currentStress;
        currentStress += stress;
        currentStress = Mathf.Clamp(currentStress, 0, maxStress);

        // Check if stress level crossed certain thresholds and play appropriate animations
        CheckStressThresholds();
        //Debug.Log("Current stress: " + currentStress);
    }

    public void RemoveStress(float stress)
    {
        oldStress = currentStress;
        currentStress -= stress;
        currentStress = Mathf.Clamp(currentStress, 0, maxStress);

        // Check if stress level crossed certain thresholds and play appropriate animations
        CheckStressThresholds();
    }

    private void PlayAnimation(string animationName)
    {
        if (stressAnimator != null)
        {
            stressAnimator.Play(animationName);
            StartCoroutine(UpdateSpriteAfterAnimation(animationName)); // Start a coroutine to update the sprite after animation finishes
        }
    }

    private IEnumerator UpdateSpriteAfterAnimation(string animationName)
    {
        yield return new WaitForSeconds(stressAnimator.GetCurrentAnimatorStateInfo(0).length); // Wait for the animation to finish
        UpdateStressBar(); // Update stress bar visuals after animation finishes
    }

    private void UpdateStressBar()
    {
        if (stressImage != null && stressSprites != null && stressSprites.Length > 0)
        {
            // Calculate the index of the sprite based on the current stress level
            int spriteIndex = Mathf.FloorToInt(currentStress / maxStress * (stressSprites.Length - 1));
            // Ensure the sprite index stays within bounds
            spriteIndex = Mathf.Clamp(spriteIndex, 0, stressSprites.Length - 1);
            // Set the sprite to the appropriate one based on the stress level
            stressImage.sprite = stressSprites[spriteIndex];

            // Debug.Log to verify if the sprite has changed
            Debug.Log("Stress sprite changed to: " + stressSprites[spriteIndex]);
        }
    }

    private void CheckStressThresholds()
    {
        if (currentStress == 100 && oldStress < 100)
        {
            PlayAnimation("75_to_100");
            Debug.Log("75_to_100 animation played!");
        }
        else if (currentStress >= 75 && oldStress < 75)
        {
            PlayAnimation("50_to_75");
            Debug.Log("50_to_75 animation played!");
        }
        else if (currentStress >= 50 && oldStress < 50)
        {
            PlayAnimation("25_to_50");
            Debug.Log("25_to_50 animation played!");
        }
        else if (currentStress >= 25 && oldStress < 25)
        {
            PlayAnimation("0_to_25");
            Debug.Log("0_to_25 animation played!");
        }
        else if (currentStress < 100 && oldStress == 100)
        {
            PlayAnimation("100_to_75");
            Debug.Log("100_to_75 animation played!");
        }
        else if (currentStress < 75 && oldStress >= 75)
        {
            PlayAnimation("75_to_50");
            Debug.Log("75_to_50 animation played!");
        }
        else if (currentStress < 50 && oldStress >= 50)
        {
            PlayAnimation("50_to_25");
            Debug.Log("50_to_25 animation played!");
        }
        else if (currentStress < 25 && oldStress >= 25)
        {
            PlayAnimation("25_to_0");
            Debug.Log("25_to_0 animation played!");
        }
    }
}