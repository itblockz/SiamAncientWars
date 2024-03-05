using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " WAVE(S) CLEARED";
    }

    public void RestartButton()
    {
        int level = LevelSelector.selectedLevel;
        SceneManager.LoadSceneAsync("Map " + level);
    }

    public void ExitButton()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void NextButton()
    {
        LevelSelector.selectedLevel++;
        Debug.Log(LevelSelector.selectedLevel);
        SceneManager.LoadSceneAsync("TowerSelection");
    }
}
