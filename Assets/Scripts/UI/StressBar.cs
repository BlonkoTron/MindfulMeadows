    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class StressBar : MonoBehaviour
    {
        private float currentStress;
        private readonly int maxStress = 100;
        public Sprite[] stressSprites;
        public Image stressImage;
        public Text stressText;

    void Start()
    {
        currentStress = 0;
    }
    void Update()
    {
        AddStress(0.01f);
    }
    public void AddStress(float stress)
    {
        currentStress += stress;
        if (currentStress > maxStress)
        {
            currentStress = maxStress;
        }
        UpdateStressBar();
    }
    public void RemoveStress(float stress)
    {
        currentStress -= stress;
        if (currentStress < 0)
        {
            currentStress = 0;
        }
        UpdateStressBar();
    }
    public float GetCurrentStress()
    {
        UpdateStressBar();
        return currentStress;
    }
    public void UpdateStressBar()
    {
        float ratio = (float)currentStress / (float)maxStress;

        int index = 0;

        if (ratio >= 1f)
        {
            index = 4; // 100% stress
        }
        else if (ratio >= 0.75f)
        {
            index = 3; // 75-99% stress
        }
        else if (ratio >= 0.5f)
        {
            index = 2; // 50-74% stress
        }
        else if (ratio >= 0.25f)
        {
            index = 1; // 25-49% stress
        }
        else if (ratio >= 0.0f)
        {
            index = 0; // 0-25% stress
        }

        if (stressImage != null && stressSprites != null && stressSprites.Length > 0)
        {
            stressImage.sprite = stressSprites[index];
        }

        if (stressText != null)
        {
            stressText.text = "Stress: " + currentStress.ToString();
        }
    }
}
