using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpdate : MonoBehaviour
{
    public InputController input;

    public Text speedText;

    private void Start()
    {
        UpdateSpeedTest();
    }

    public void IncreseSpeed()
    {
        input.playerSpeed++;
        UpdateSpeedTest();
    }

    public void DescreaseSpeed()
    {
        input.playerSpeed--;
        UpdateSpeedTest();
    }

    void UpdateSpeedTest()
    {
        speedText.text = input.playerSpeed.ToString(CultureInfo.InvariantCulture);
    }
}