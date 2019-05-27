using UnityEngine;

public class TwoJoysticksUpdate : MonoBehaviour
{
    public Joystick movementJoystick;
    public Joystick rotationJoystick;

    public InputController inputController;

    void FixedUpdate()
    {
        inputController.movement.x = movementJoystick.Horizontal;
        inputController.movement.y = movementJoystick.Vertical;

        inputController.rotation.x = rotationJoystick.Horizontal;
        inputController.rotation.y = rotationJoystick.Vertical;
    }
}