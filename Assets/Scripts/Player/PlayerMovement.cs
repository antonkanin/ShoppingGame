using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 0.1f;

    public Camera gameCamera;

    public InputController input;

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

        if (Math.Abs(input.movement.x) < ZERO_SPEED &&
            Math.Abs(input.movement.y) < ZERO_SPEED)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            var newPlayerPos = playerSpeed * (transform.forward * input.movement.y +
                                              transform.right * input.movement.x);

            rb.MovePosition(transform.position + newPlayerPos);
        }
    }

    void HandleRotationJoystick()
    {
        gameCamera.transform.rotation *=
            Quaternion.Euler(-1.0f * input.rotation.y, 0.0f, 0.0f);

        rb.MoveRotation(transform.rotation * Quaternion.Euler(0.0f, input.rotation.x, 0.0f));
    }
}