using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    private static List<Tower> towers;
    public static List<Tower> Towers { get => towers; }

    private int selectedTower = 0;

    private void Awake() {
        main = this;
        towers = new List<Tower>();
    }

    public Tower GetSelectedTower() {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower) {
        selectedTower = _selectedTower;
    }
}
