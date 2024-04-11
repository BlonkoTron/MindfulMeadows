using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    private Vector3 lastPosition;
    private Animator animator;

    private Vector3 movement;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector3>();

        if (PlayerMovement.instance.canMove)
        {
            if (movement != Vector3.zero)
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }


    }

    private void OnJump(InputValue value)
    {
           
        if (PlayerMovement.instance.canMove)
        {
            animator.SetBool("IsJumping", true);
        }
    }

    void Update() 
    {
        if (controller.isGrounded)
        {
            animator.SetBool("IsGrounded", true);
            animator.SetBool("IsFalling", false);
            
        }
        else if (!controller.isGrounded)
        {
            animator.SetBool("IsGrounded", false);
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
    }

}