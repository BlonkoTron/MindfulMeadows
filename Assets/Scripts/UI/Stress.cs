using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stress : MonoBehaviour
{
    public int MaxStress = 100;
    public int CurrentStress;
    public int StartingStress = 0;

    public StressBar stressBar;

    void Start()
    {
        CurrentStress = StartingStress;
        stressBar.SetStress(CurrentStress);
        stressBar.SetMaxStress(MaxStress);
    }
    void Update()
    {
        if (OnTriggerEnter)
        {
            RecieveStress(10);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RecieveStress(10);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ReduceStress(10);
        }
        */
    }

    void RecieveStress(int stress)
    {
        CurrentStress += stress;
        stressBar.SetStress(CurrentStress);
        if (CurrentStress > MaxStress)
        {
            CurrentStress = MaxStress;
        }
    }
    void ReduceStress(int stress)
    {
        CurrentStress -= stress;
        stressBar.SetStress(CurrentStress);
        if (CurrentStress < 0)
        {
            CurrentStress = 0;
        }
    }
}
