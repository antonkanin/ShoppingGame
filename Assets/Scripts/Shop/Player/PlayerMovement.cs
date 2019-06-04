using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera gameCamera;

    public InputController input;

    private Rigidbody rigidBody;

    // зело скверно использовать такое значение,
    // ниже описал подробнее
    private const float PLAYER_SPEED = 0.01f;

    private void Start()
    {
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
            // эту часть я вынес, чтобы показать проблему с вычислением скорости таким образом.
            // если я жму "вперёд", длина вектора движения будет равна 1.
            // если "вправо", тоже 1.
            // а вот если "вперёд" и "вправо" одновременно, то вектора сложатся и у меня получится вектор (1,1) -
            // длина корень из двух.
            Vector3 positionChange = (transform.forward * input.movement.y + transform.right * input.movement.x);

            // чтобы это исправить, нормализуйте вектор.
            positionChange.Normalize();

            // если DeltaTime меняется, персонаж будет двигаться быстрее или медленнее 
            // в зависимости от частоты смены кадров. Здесь используется FixedUpdate, да - это подавит 
            // зависимость от частоты кадров, но зависимость от величины FixedUpdate останется. Я поменял это значение
            // в настройках, чтобы продемонстрировать.
            // чтобы компенсировать это, я поменял PLAYER_SPEED ниже на Time.deltaTime.
            var newPlayerPos = input.playerSpeed * Time.deltaTime * positionChange;

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