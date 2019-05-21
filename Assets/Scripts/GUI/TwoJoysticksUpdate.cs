using UnityEngine;

public class TwoJoysticksUpdate : MonoBehaviour
{
    public Joystick movementJoystick;
    public Joystick rotationJoystick;

    public Vector2Value movement;
    public Vector2Value rotation;

    void FixedUpdate()
    {
        movement.value.x = movementJoystick.Horizontal;
        movement.value.y = movementJoystick.Vertical;

        rotation.value.x = rotationJoystick.Horizontal;
        rotation.value.y = rotationJoystick.Vertical;
    }
}