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
            playerSpeed * new Vector3(movementJoystick.Horizontal, 0.0f, movementJoystick.Vertical);
    }

    void HandleRotationJoystick()
    {
        var rot = gameCamera.transform.rotation;
        
        rot *= Quaternion.Euler(-1.0f * rotationJoystick.Vertical, rotationJoystick.Horizontal, 0.0f);
        
        gameCamera.transform.rotation = rot;
    }
}