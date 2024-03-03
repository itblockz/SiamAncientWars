using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerCollection : MonoBehaviour
{
    public static TowerCollection main { get; private set; }
    [SerializeField] private Tower[] towers;
    public Tower[] Towers { get => towers; }

    private void Awake() {
        main = this;
    }

    public Tower GetTowerByName(string name) {
        foreach (Tower tower in towers)
        {
            if (tower.name == name) return tower;
        }
        return null;
    }
}
