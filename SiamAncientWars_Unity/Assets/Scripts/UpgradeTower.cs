using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTower: MonoBehaviour
{
    [SerializeField] private GameObject upgradeUI;
    [HideInInspector] public Tower tower;

    public void OpenUpgradeUI() {
        upgradeUI.SetActive(true);
    }
    public void CloseUpgradeUI() {
        upgradeUI.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }
}
