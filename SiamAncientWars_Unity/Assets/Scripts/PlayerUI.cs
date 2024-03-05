using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI userName;

    public void Start()
    {
        userName.text = Player.main.UserName;
    }
}
