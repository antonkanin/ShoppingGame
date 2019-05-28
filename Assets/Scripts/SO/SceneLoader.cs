using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneLoader : ScriptableObject
{
    // Start is called before the first frame update
    public string shopScene;
    public string homeScene;

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadHome()
    {
        LoadScene(homeScene);
    }

    public void LoadShop()
    {
        LoadScene(shopScene);
    }
}