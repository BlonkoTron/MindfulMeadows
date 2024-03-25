using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{

    [SerializeField] private float growTime;
    [SerializeField] private GameObject tree;

    private float currentGrowTime;
    private bool canGrow = true;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        currentGrowTime = 0;
    }

    private void FixedUpdate()
    {
        if (currentGrowTime < growTime)
        {
            currentGrowTime += Time.fixedDeltaTime;
        }
        else
        {
            if (canGrow)
            {
                Destroy(gameObject);
            }
           
        }
    }

    private void OnDestroy()
    {
        tree.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canGrow = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canGrow = true;
        }
    }

}
