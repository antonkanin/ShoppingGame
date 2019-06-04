using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneLoader : ScriptableObject
{
    public string mainMenuScene;
    public string shopScene;
    public string homeScene;

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadMainMenu()
    {
        LoadScene(mainMenuScene);
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