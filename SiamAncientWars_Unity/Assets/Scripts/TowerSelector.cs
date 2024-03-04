using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject selectedUI;

    [HideInInspector] public Tower tower;

    public void SetSelected()
    {
        if (selectedUI.activeSelf)
        {
            selectedUI.SetActive(false);
            TowerSelectManager.main.Remove(tower);
        }
        else
        {
            selectedUI.SetActive(true);
            TowerSelectManager.main.Add(tower);
        }
    }
}
