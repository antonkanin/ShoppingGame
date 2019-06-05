using UnityEngine;
using UnityEngine.UI;

public class DebugLog : MonoBehaviour
{
    public Text logText;

    public GameObject logPanel;

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logText.text += logString + "\n"; 
    }

    public void ShowHideLog()
    {
        logPanel.SetActive(!logPanel.activeSelf);
    }
}
