using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 0.1f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Camera gameCamera;

    public Joystick movementJoystick;
    public Joystick rotationJoystick;

    void Update()
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
        transform.position +=
            playerSpeed *
            (transform.forward * movementJoystick.Vertical + transform.right * movementJoystick.Horizontal);
    }

    void HandleRotationJoystick()
    {
        // turning camera (only up and down)
        gameCamera.transform.rotation *=
            Quaternion.Euler(-1.0f * rotationJoystick.Vertical, 0.0f, 0.0f);

        // turning player (only left and right)
        transform.rotation *=
            Quaternion.Euler(0.0f, rotationJoystick.Horizontal, 0.0f);
    }
}