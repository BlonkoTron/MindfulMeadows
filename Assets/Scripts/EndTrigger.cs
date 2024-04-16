using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    [SerializeField] private GameObject endScreen;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            endScreen.SetActive(true);
            PlayerMovement.instance.canMove = false;
            WritingDataManager.SerializeXML();
        }
    }

}
