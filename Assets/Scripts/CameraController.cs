using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private CinemachineBrain cBrain;

    private void Awake()
    {
        instance = this;
        cBrain = GetComponent<CinemachineBrain>();
    }

    public void StopCamera()
    {
        if (cBrain.enabled != false) 
        {
            cBrain.enabled = false;
            Debug.Log(cBrain.enabled);
        }
        
    }

    public void StartCamera()
    {   
        if (cBrain.enabled != true)
        {
            cBrain.enabled = true;
            Debug.Log(cBrain.enabled);
        }
        
    }

}
