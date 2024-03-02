using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        int level = LevelSelector.selectedLevel;
        SceneManager.LoadSceneAsync("Map " + level);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void SelectTowers() {
        SceneManager.LoadSceneAsync("TowerSelection");
    }

    public void SelectMap() {
        SceneManager.LoadSceneAsync("MapSelection");
    }
}
