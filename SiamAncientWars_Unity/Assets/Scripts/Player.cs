using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player main;

    [Header("Attributes")]
    public string userName = "Anonymous";
    [SerializeField] private PlayerUI playerUI;

    private int maxCleared = 0;

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

    private void Start()
    {
        LoadPlayer();
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

        playerUI.SetPlayer();
    }

    public void ResetPlayer()
    {
        maxCleared = 0;
        SavePlayer();
        LoadPlayer();
    }
}
