using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player main;

    [Header("Attributes")]
    public string userName = "Anonymous";
    [SerializeField] private PlayerUI playerUI;

    private int mapCleared = 0;

    public int MapCleared
    {
        get => mapCleared;
        set
        {
            mapCleared = value;
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
        MapCleared = data.mapCleared;

        playerUI.SetPlayer();
    }

    public void ResetPlayer()
    {
        mapCleared = 0;
        SavePlayer();
        LoadPlayer();
    }
}
