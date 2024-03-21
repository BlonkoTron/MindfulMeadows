using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    private int currentStress;
    private int maxStress = 100;
    public Image barFillImage;

    void Start()
    {
        currentStress = 0;
       // UpdateStressBar();
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
      //  UpdateStressBar();
    }
    public void RemoveStress(int stress)
    {
        currentStress -= stress;
        if (currentStress < 0)
        {
            currentStress = 0;
        }
       // UpdateStressBar();
    }
}
