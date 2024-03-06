using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI nameTurret;
    [SerializeField] private Image img;
    [SerializeField] private UpgradeTower upgrade;
    public bool mouse_over = false;

    public void OnPointerEnter(PointerEventData eventData) {
        mouse_over = true;
        UIManager.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        mouse_over = false;
        UIManager.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }
    private void Update(){
        img.sprite = upgrade.tower.sprite;
        nameTurret.text = upgrade.tower.name;
    }
}
