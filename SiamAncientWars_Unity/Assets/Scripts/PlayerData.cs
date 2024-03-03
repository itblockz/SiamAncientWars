using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int mapCleared;

    public PlayerData(Player player) {
        name = player.userName;
        mapCleared = player.MapCleared;
    }
}
