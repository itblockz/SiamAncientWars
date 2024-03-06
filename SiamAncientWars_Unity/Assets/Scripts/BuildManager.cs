using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [HideInInspector] public List<Tower> towers;

    public int selectedTower = 0;

    private void Awake()
    {
        main = this;
        towers = new List<Tower>();
    }

    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }
}
