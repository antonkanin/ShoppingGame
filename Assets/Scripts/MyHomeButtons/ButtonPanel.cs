using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool objectActive = false;


    public void showhidePannel()
    {
        if (objectActive == true) 
        {
            panel.gameObject.SetActive(false);
            objectActive = false;
        }
        else if(objectActive == false)
        {
            panel.gameObject.SetActive(true);
            objectActive = true;
        }
    }
}
