using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    #region movement values
    [Header("Movementstuff")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    public bool isGrounded = false;
    public bool canJump = true;
    public bool canMove = true;

    #endregion

    [Header("Others")]
    [SerializeField] private Transform cameraTransform;


    #region private stuff
    private Vector3 movement;
    private Rigidbody rb;

    #endregion

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

        if (movement != null)
        {

            if (movement != Vector3.zero)
            {
                Quaternion toRoataion = Quaternion.LookRotation(movement, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoataion, rotationSpeed * Time.fixedDeltaTime);
            }

            float magnitude = Mathf.Clamp01(movement.magnitude);
            transform.Translate(movement.normalized * magnitude * speed * Time.fixedDeltaTime);

        }
        #endregion
    }

    void OnMovement(InputValue input)
    {   
        if (canMove)
        {
            movement = input.Get<Vector3>();
            movement = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
        }
        else
        {
            movement = Vector3.zero;
        }

    }

    void OnJump(InputValue input)
    {   
        if (isGrounded && canMove)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

}
