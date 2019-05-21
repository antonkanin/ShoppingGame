using UnityEngine;
using UnityEngine.UI;

public class InputSelector : MonoBehaviour
{
    public Toggle twoJoysticksToggle;
    public Toggle oneJoysticksToggle;
    public Toggle buttonsToggle;

    private void Start()
    {
        twoJoysticksToggle.isOn = true;
        oneJoysticksToggle.isOn = false;
        buttonsToggle.isOn = false;
    }

    public void SelectToggle(Toggle toggle)
    {
/*
        twoJoysticksToggle.isOn = twoJoysticksToggle.isOn != twoJoysticksToggle;
        oneJoysticksToggle.isOn = oneJoysticksToggle.isOn != twoJoysticksToggle;
        buttonsToggle.isOn = buttonsToggle.isOn != twoJoysticksToggle;
*/
    }
    
}
