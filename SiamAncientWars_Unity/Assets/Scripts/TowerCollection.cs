using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerCollection : MonoBehaviour
{
    public static TowerCollection main;
    public Tower[] towers;

    private void Awake()
    {
        main = this;
    }

    public Tower GetTowerByName(string name)
    {
        foreach (Tower tower in towers)
        {
            if (tower.name == name) return tower;
        }
        return null;
    }
}
