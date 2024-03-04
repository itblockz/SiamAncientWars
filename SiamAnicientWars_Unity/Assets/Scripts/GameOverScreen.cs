using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " WAVES CLEARED";
    }

    public void RestartButton() {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton() {
        // SceneManager.LoadScene("MainMenu");
    }
}
