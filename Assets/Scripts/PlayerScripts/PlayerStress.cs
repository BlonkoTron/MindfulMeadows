using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStress : MonoBehaviour
{

    public static PlayerStress instance;

    public float stressLevel;
    [SerializeField] private float startStress;
    [SerializeField] private float maxStress;
    
    public void RemoveStress(float reduction)
    {
        stressLevel -= reduction;
    }


}
