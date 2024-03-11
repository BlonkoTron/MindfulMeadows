using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;


    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public bool isGrounded = false;

    private Vector3 movement;
    private Rigidbody rb;



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement

        transform.Translate(movement.normalized * speed * Time.fixedDeltaTime);

        #endregion
    }

    void OnMovement(InputValue input)
    {
        movement = input.Get<Vector3>();

    }

    void OnJump(InputValue input)
    {   
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }


}
