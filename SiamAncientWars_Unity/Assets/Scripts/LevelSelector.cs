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
    [SerializeField] private GameObject clearedUI;
    
    [Header("Attributes")]
    [SerializeField] private int level;

    private void Start() {
        if (level <= Player.main.MaxCleared) clearedUI.SetActive(true);
    }

    public void OpenScene() {
        selectedLevel = level;
        SceneManager.LoadSceneAsync("TowerSelection");
    }
}
