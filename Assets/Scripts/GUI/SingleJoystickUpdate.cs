using UnityEngine;

public class SingleJoystickUpdate : MonoBehaviour
{
    public Joystick joystick;

    public InputController inputController;

    void Update()
    {
        inputController.movement.y = joystick.Vertical;
        inputController.rotation.x = joystick.Horizontal;
    }
}