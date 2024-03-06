using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject selectedPrefab;

    private List<GameObject> selectedUIs;

    private void Start() {
        selectedUIs = new List<GameObject>();
        List<Tower> towers = BuildManager.main.towers;

        for (int i = 0; i < towers.Count; i++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, transform);

            GameObject selectedObj = Instantiate(selectedPrefab, buttonObj.transform);
            selectedUIs.Add(selectedObj);

            Button button = buttonObj.GetComponent<Button>();
            int selectedTower = i;
            button.onClick.AddListener(delegate {
                BuildManager.main.SetSelectedTower(selectedTower);
                UnselectAll();
                selectedObj.SetActive(true);
            });
            
            Image image = buttonObj.GetComponent<Image>();
            image.sprite = towers[i].sprite;
        }
        selectedUIs[BuildManager.main.selectedTower].SetActive(true);
    }

    public void UnselectAll()
    {
        foreach (GameObject obj in selectedUIs)
        {
            obj.SetActive(false);
        }
    }
}
