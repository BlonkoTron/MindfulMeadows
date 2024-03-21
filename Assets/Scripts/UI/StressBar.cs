    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class StressBar : MonoBehaviour
    {
        private int currentStress;
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
            AddStress(1);       
        }
        public void AddStress(int stress)
        {
            currentStress += stress;
            if (currentStress > maxStress)
            {
                currentStress = maxStress;
            }
            UpdateStressBar();
        }
        public void RemoveStress(int stress)
        {
            currentStress -= stress;
            if (currentStress < 0)
            {
                currentStress = 0;
            }
            UpdateStressBar();
        }
        public int GetCurrentStress()
        {
            UpdateStressBar();
            return currentStress;
        }
        public void UpdateStressBar()
        {
            float ratio = (float)currentStress / (float)maxStress;
            int index = (int)(ratio * stressSprites.Length);

            if (index >= stressSprites.Length)
            {
                index = stressSprites.Length - 1;
            }

            if (stressImage != null && stressSprites != null && stressSprites.Length > 0)
            {
                stressImage.sprite = stressSprites[index];
            }
        }
    }
