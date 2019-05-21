using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 0.1f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Camera gameCamera;

    public Vector2Value rotationValue;
    public Vector2Value movementValue;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovementJoystick();
        HandleRotationJoystick();
    }

    void HandleMovementJoystick()
    {
        const float ZERO_SPEED = 0.1f;

        if (Math.Abs(movementValue.value.x) < ZERO_SPEED &&
            Math.Abs(movementValue.value.y) < ZERO_SPEED)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            var newPlayerPos = playerSpeed * (transform.forward * movementValue.value.y +
                                              transform.right * movementValue.value.x);

            rb.MovePosition(transform.position + newPlayerPos);
        }
    }

    void HandleRotationJoystick()
    {
        // turning camera (only up and down)
        gameCamera.transform.rotation *=
            Quaternion.Euler(-1.0f * rotationValue.value.y, 0.0f, 0.0f);

        rb.MoveRotation(transform.rotation * Quaternion.Euler(0.0f, rotationValue.value.x, 0.0f));
    }
}