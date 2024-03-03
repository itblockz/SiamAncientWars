using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI mapCleared;

    public void SetPlayer()
    {
        userName.text = Player.main.userName;
        mapCleared.text = Player.main.MapCleared.ToString();
    }
}
