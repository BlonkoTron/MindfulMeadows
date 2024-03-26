using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public Transform lineEndPoint;

    private void Awake()
    {
        if (lineEndPoint=null)
        {
            lineEndPoint=GetComponent<Transform>();
        }
    }
    public void ChangeState()
    {
        Debug.Log("area cleared");
    }
}
