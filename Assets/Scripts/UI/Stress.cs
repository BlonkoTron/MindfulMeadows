using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stress : MonoBehaviour
{
    public Slider stressSlider;
    public Gradient stressGradient;
    public Image fill;

    public void SetMaxStress(int stress)
    {
        stressSlider.maxValue = stress;
        stressSlider.value = stress;

        fill.color = stressGradient.Evaluate(1f);
    }
    public void SetStress(int stress)
    {
        stressSlider.value = stress;
        fill.color = stressGradient.Evaluate(stressSlider.normalizedValue);
    }
}
