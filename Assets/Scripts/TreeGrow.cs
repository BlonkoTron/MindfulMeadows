using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrow : MonoBehaviour
{

    [SerializeField] private GameObject treeText;
    [SerializeField] private float growRate;
    [SerializeField] private GameObject leafParticle;


    private void OnEnable()
    {
        treeText.GetComponent<Billboard>().enabled = false;
        Instantiate(leafParticle, this.transform);
    }

    private void FixedUpdate()
    {
        if (isActiveAndEnabled)
        {
            if (transform.localScale.x < 1)
            {
                transform.localScale += Vector3.one * growRate * Time.fixedDeltaTime;
            }
            
        }
    }



}
