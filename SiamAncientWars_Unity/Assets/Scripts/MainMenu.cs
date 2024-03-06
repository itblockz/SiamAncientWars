using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu main;

    private void Awake()
    {
        main = this;
    }

    public void PlayGame()
    {
        int level = LevelSelector.selectedLevel;
        SceneManager.LoadSceneAsync("Map " + level);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void SelectTowers()
    {
        SceneManager.LoadSceneAsync("TowerSelection");
    }

    public void SelectMap()
    {
        SceneManager.LoadSceneAsync("MapSelection");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
