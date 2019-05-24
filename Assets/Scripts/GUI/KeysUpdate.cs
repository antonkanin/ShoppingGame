using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysUpdate : MonoBehaviour
{
    public InputController inputController;

    // Start is called before the first frame update
    public void ButtonLeftDown()
    {
        inputController.rotation.x = -1.0f;
    }

    public void ButtonRightDown()
    {
        inputController.rotation.x = 1.0f;
    }

    public void ButtonUp()
    {
        inputController.rotation.x = 0.0f;
    }
}