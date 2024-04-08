using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public Transform lineEndPoint;
    public int connectedObjects;

    private void Awake()
    {
        if (lineEndPoint=null)
        {
            lineEndPoint=GetComponent<Transform>();
        }
    }
    public void ChangeState()
    {
        connectedObjects--;
        if (connectedObjects==0)
        {
            Debug.Log("area cleared");

            Destroy(gameObject);
        }
    }
}
