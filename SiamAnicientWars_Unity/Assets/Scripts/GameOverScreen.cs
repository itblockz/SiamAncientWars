using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " WAVE(S) CLEARED";
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
