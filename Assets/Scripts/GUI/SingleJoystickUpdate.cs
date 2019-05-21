using UnityEngine;

public class SingleJoystickUpdate : MonoBehaviour
{
    public Joystick Joystick;

    public Vector2Value movement;
    public Vector2Value rotation;

    void Update()
    {
        movement.value.y = Joystick.Vertical;
        rotation.value.x = Joystick.Horizontal;
    }
}