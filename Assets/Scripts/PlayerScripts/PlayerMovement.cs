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
    [SerializeField] private float jumpGracePeriod;
    public bool isGrounded = false;
    public bool canJump = true;
    public bool canMove = true;

    #endregion

    #region private stuff
    //private variables
    private Vector3 movement;
    private Vector3 velocity;

    private float ySpeed;
    private float? lastGroundedTime = null;
    private float? lastJumpPress = null;

    //private components
    private Rigidbody rb;
    private CharacterController controller;

    //GameObjects
    private GameObject mainCamera;
    private Transform cameraTransform;


    #endregion

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraTransform = mainCamera.transform;

    }

    // Update is called once per frame
    void Update()
    {
#region Movement

            if (movement != Vector3.zero)
            {
                Quaternion toRoataion = Quaternion.LookRotation(movement, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoataion, rotationSpeed * Time.deltaTime);
            }

        float magnitude = Mathf.Clamp01(movement.magnitude) * speed;

        velocity = movement * magnitude;

#endregion

#region Calculating Jump

        ySpeed += Physics.gravity.y * Time.deltaTime;

        velocity.y = ySpeed;

        if (controller.isGrounded)
        {
            lastGroundedTime = Time.time;
        }


#endregion

#region Moving the Character

       controller.Move(velocity * Time.deltaTime);

#endregion

    }

    void OnMovement(InputValue input)
    {
        if (canMove)
        {
            movement = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * input.Get<Vector3>();
        }
        else
        {
            movement = Vector3.zero;
        }
        
    }

    void OnJump(InputValue input)
    {
        
        lastJumpPress = Time.time;

        if (canMove && canJump)
        {   
            if (Time.time - lastGroundedTime <= jumpGracePeriod)
            {   

                if (Time.time - lastJumpPress <= jumpGracePeriod) 
                {
                    ySpeed = jumpForce;
                    lastJumpPress = null;
                    lastGroundedTime = null;
                }
                
            }
        }

    }

}