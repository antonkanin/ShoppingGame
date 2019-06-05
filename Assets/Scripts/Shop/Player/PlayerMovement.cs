using System;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera gameCamera;

    private InputController input;
    
    private Rigidbody rigidBody;

    private const float PLAYER_SPEED = 0.01f;

    private void Start()
    {
        input = Utils.FindInputController().GetComponent<InputController>();

        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // HandleMovementJoystick();
        MovePlayer();

        HandleRotationJoystick();
    }

    void HandleMovementJoystick()
    {
        const float ZERO_SPEED = 0.1f;

        if (Math.Abs(input.movement.x) < ZERO_SPEED &&
            Math.Abs(input.movement.y) < ZERO_SPEED)
        {
            rigidBody.velocity = Vector3.zero;
        }
        else
        {
            var newPlayerPos = input.playerSpeed * PLAYER_SPEED * (transform.forward * input.movement.y +
                                                                   transform.right * input.movement.x);

            rigidBody.MovePosition(transform.position + newPlayerPos);
        }
    }

    void HandleRotationJoystick()
    {
        gameCamera.transform.rotation *=
            Quaternion.Euler(-1.0f * input.rotation.y, 0.0f, 0.0f);

        rigidBody.MoveRotation(transform.rotation * Quaternion.Euler(0.0f, input.rotation.x, 0.0f));
    }

    void MovePlayer()
    {
        if (input.isMoving)
        {
            rigidBody.MovePosition(transform.position + input.playerSpeed * PLAYER_SPEED * transform.forward);
        }
    }
}