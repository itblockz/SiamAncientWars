using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int maxCleared;

    public PlayerData(Player player) {
        name = player.UserName;
        maxCleared = player.MaxCleared;
    }
}
