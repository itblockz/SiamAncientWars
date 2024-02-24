using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject buttonPrefab;

    private void Start() {
        Tower[] towers = BuildManager.main.Towers;

        for (int i = 0; i < towers.Length; i++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, transform);
            Button button = buttonObj.GetComponent<Button>();
            int selectedTower = i;
            button.onClick.AddListener(delegate {
                BuildManager.main.SetSelectedTower(selectedTower);
            });
            
            Image image = buttonObj.GetComponent<Image>();
            image.sprite = towers[i].sprite;
        }
    }
}
