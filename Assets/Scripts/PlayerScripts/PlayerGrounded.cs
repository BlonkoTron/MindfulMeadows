using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{


    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Ground"))
        {
            PlayerMovement.instance.isGrounded = true;
            Debug.Log("the ground gone");
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Ground"))
        {
            PlayerMovement.instance.isGrounded = false;

            Debug.Log("Yo thats some fucking ground");


        }
    }

}
