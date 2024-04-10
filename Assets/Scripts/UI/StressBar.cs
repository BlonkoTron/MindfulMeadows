using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StressBar : MonoBehaviour
{
    public Slider stressSlider;
    public Gradient stressGradient;
    public Image fill;

    public void SetMaxStress(float stress)
    {
        stressSlider.maxValue = stress;
        fill.color = stressGradient.Evaluate(1f);
    }

    public void SetStress(float stress)
    {
        stressSlider.value = stress;
        fill.color = stressGradient.Evaluate(stressSlider.normalizedValue);
    }
    public float GetStress()
    {
        return stressSlider.value;
    }
}
