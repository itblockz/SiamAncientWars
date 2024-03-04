using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectManager : MonoBehaviour
{
    public static TowerSelectManager main;

    [Header("References")]
    [SerializeField] private GameObject towerButton;
    [SerializeField] private Transform[] standing;
    [SerializeField] private GameObject towerUI;

    private List<Tower> selectedTowers;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        foreach (Tower tower in TowerCollection.main.towers)
        {
            GameObject button = Instantiate(towerButton, transform);
            button.GetComponent<Image>().sprite = tower.sprite;
            button.GetComponent<TowerSelector>().tower = tower;
        }
        selectedTowers = new();
    }

    public void Add(Tower tower)
    {
        selectedTowers.Add(tower);
        ShowModel();
    }

    public void Remove(Tower tower)
    {
        selectedTowers.Remove(tower);
        ShowModel();
    }

    private void ShowModel()
    {
        for (int i = 0; i < standing.Length; i++)
        {
            for (int j = 0; j < standing[i].childCount; j++)
            {
                Transform child = standing[i].GetChild(j);
                Destroy(child.gameObject);
            }
            if (i < selectedTowers.Count)
            {
                GameObject tower = Instantiate(towerUI, standing[i].transform);
                tower.GetComponent<Image>().sprite = selectedTowers[i].sprite;
            }
        }
    }

    public void Apply()
    {
        BuildManager.main.towers = selectedTowers;
    }
}
