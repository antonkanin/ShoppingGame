using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 0.1f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Camera gameCamera;

    public Joystick movementJoystick;
    public Joystick rotationJoystick;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // HandleMovement();
        // HandleRotation();

        HandleMovementJoystick();
        HandleRotationJoystick();
    }

    void HandleMovement()
    {
        var shiftHorizontal = Input.GetAxis("Horizontal");
        var shiftVertical = Input.GetAxis("Vertical");

        transform.position += playerSpeed * new Vector3(shiftHorizontal, 0.0f, shiftVertical);
    }

    void HandleRotation()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");

        gameCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    void HandleMovementJoystick()
    {
        const float ZERO_SPEED = 0.1f;

        if (Math.Abs(movementJoystick.Vertical) < ZERO_SPEED &&
            Math.Abs(movementJoystick.Horizontal) < ZERO_SPEED)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            var newPlayerPos = playerSpeed * (transform.forward * movementJoystick.Vertical +
                                              transform.right * movementJoystick.Horizontal);

            rb.MovePosition(transform.position + newPlayerPos);
        }
    }

    void HandleRotationJoystick()
    {
        // turning camera (only up and down)
        gameCamera.transform.rotation *=
            Quaternion.Euler(-1.0f * rotationJoystick.Vertical, 0.0f, 0.0f);

        rb.MoveRotation(transform.rotation * Quaternion.Euler(0.0f, rotationJoystick.Horizontal, 0.0f));
    }
}