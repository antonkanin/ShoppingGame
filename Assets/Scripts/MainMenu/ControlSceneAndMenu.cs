using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSceneAndMenu : MonoBehaviour
{
    public GameObject ButtonsMenu;
    public GameObject Exitgame;
    
    public void ShowExitButtons()
    {
        ButtonsMenu.SetActive(false);
        Exitgame.SetActive(true);
    }

    public void BackInMenu()
    {
        ButtonsMenu.SetActive(true);
        Exitgame.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();   
    }
}
