using System.Collections;
using UnityEngine;

public class NoTargetMessage : MonoBehaviour
{
    public GameObject noTargetGUI;

    public void ShowMessage()
    {
        StartCoroutine(ShowMessage_Co());
    }

    IEnumerator ShowMessage_Co()
    {
        noTargetGUI.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        noTargetGUI.SetActive(false);
    }
}