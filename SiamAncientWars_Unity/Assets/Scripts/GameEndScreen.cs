using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void SetupLose(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "คุณพิชิตไปเพียง " + score.ToString() + " กองทัพ";
    }

    public void SetupWin()
    {
        gameObject.SetActive(true);
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
        if (LevelSelector.selectedLevel == 3) return;
        LevelSelector.selectedLevel++;
        SceneManager.LoadSceneAsync("TowerSelection");
    }
}
