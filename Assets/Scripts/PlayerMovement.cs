using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 0.1f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Camera gameCamera;

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += playerSpeed * transform.forward;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= playerSpeed * transform.forward;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += playerSpeed * transform.right;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= playerSpeed * transform.right;
        }
    }

    void HandleRotation()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");

        gameCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}