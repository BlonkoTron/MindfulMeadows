using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadArea : MonoBehaviour
{
    [HideInInspector] public int treesPlantedHere = 0;
    public int treesToClear;

    private void Update()
    {
        if(treesPlantedHere==treesToClear)
        {
            ClearArea();
        }
    }

    public void ClearArea()
    {
        Destroy(gameObject);
    }
}
