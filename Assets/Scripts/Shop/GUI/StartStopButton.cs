using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStopButton : MonoBehaviour
{
    // Start is called before the first frame update
    public InputController inputController;

    public Text buttonText;

    public void StartStopClick()
    {
        if (inputController.isMoving)
        {
            buttonText.text = "Start";
        }
        else
        {
            buttonText.text = "Stop";
        }

        inputController.isMoving = !inputController.isMoving;
    }
}