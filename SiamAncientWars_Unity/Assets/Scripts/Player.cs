using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player main;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI input;
    [SerializeField] private GameObject formUI;

    [Header("Attributes")]
    private string userName;

    private int maxCleared = 0;

    public string UserName
    {
        get => userName;
        set
        {
            userName = value;
            SavePlayer();
        }
    }

    public int MaxCleared
    {
        get => maxCleared;
        set
        {
            maxCleared = Mathf.Max(maxCleared, value);
            SavePlayer();
        }
    }

    private void Awake()
    {
        main = this;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        userName = data.name;
        MaxCleared = data.maxCleared;
    }

    public void ResetPlayer()
    {
        MaxCleared = 0;
    }

    public void Register()
    {
        UserName = input.text;
        MainMenu.main.GoToMainMenu();
    }

    public void OpenRegisterIfAbsent()
    {
        if (SaveSystem.LoadPlayer() == null)
        {
            formUI.SetActive(true);
        }
        else
        {
            LoadPlayer();
            MainMenu.main.GoToMainMenu();
        }
    }
}
