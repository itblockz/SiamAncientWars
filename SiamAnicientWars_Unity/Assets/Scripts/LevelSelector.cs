using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public static int selectedLevel;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI levelText;
    
    [Header("Attributes")]
    [SerializeField] private int level;

    private void Start() {
        levelText.text = "Level " + level.ToString();
    }

    public void OpenScene() {
        selectedLevel = level;
        SceneManager.LoadSceneAsync("TowerSelection");
    }
}
