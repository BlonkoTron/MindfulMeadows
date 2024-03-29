using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    #region movement values
    [Header("Movementstuff")]
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float jumpGracePeriod = 0.1f;
    [SerializeField] private float accelerationTimeToMax = 2.5f;
    [SerializeField] private float deccelerationTimeToZero = 0.8f;
    [SerializeField] private float currentSpeed;
    private float accelRate;
    private float decelRate;

    public bool isGrounded = false;
    public bool canMove = true;

    #endregion

    #region private stuff
    //private variables
    private Vector3 movement;
    private Vector3 lastMovement;
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

        accelRate = maxSpeed / accelerationTimeToMax;

        decelRate = -maxSpeed / deccelerationTimeToZero;

    }

    
    void Update()
    {
#region Calculating Movement

        if (movement != Vector3.zero)
        {   

            // Here we calculate the rotation of the character to see what direction it should be facing
            // we are also rotating it
            Quaternion toRoataion = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRoataion, rotationSpeed * Time.deltaTime);

            // Calculation of the current speed bu the acceleration rate
            //mathf.min is used to take the smaller value of either currentSpeed or maxSpeed since we don't want currentSpeed if its larger than maxSpeed
            currentSpeed += accelRate * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        }
        else
        {   
            // Almost the same as acceleration instead mathf.max to take the larger value
            currentSpeed += decelRate * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0);
        }

        // here we calculate the direction our character should be moving based on the camera position
        Vector3 direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement.normalized;

        // Here we determine the magnitude of the vector for the movement which corelates to the speed our character should move with.
        float magnitude = Mathf.Clamp01(movement.magnitude) * currentSpeed;

        velocity = movement + direction * magnitude;
        
#endregion

#region Calculating Jump

        // using unity physics to change the speed of the velocity on the y axis.

        ySpeed += Physics.gravity.y * Time.deltaTime;

        velocity.y = ySpeed;

        if (controller.isGrounded)
        {
            lastGroundedTime = Time.time;
        }


#endregion

#region Moving the Character


        if (canMove)
        {   
            // using the character controller component to move the character.
            controller.Move(velocity * Time.deltaTime);
        }
        

#endregion

    }

    void OnMovement(InputValue input)
    {   

        // inputsystem for movement is our input
        if (canMove)
        {
            movement = input.Get<Vector3>();
        }
        else
        {
            movement = Vector3.zero;
        }

        

    }

    void OnJump(InputValue input)
    {
        
        lastJumpPress = Time.time;

        if (canMove)
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