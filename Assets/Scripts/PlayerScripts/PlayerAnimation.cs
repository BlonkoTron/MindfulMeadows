using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Vector3 lastPosition;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != lastPosition)
        {
            animator.SetBool("Is moving", true);
        }
        else
        {
            animator.SetBool("Is moving", false);
        }

        lastPosition = transform.position;
    }
}