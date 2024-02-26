using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public void SetTowers() {
        List<PanelSettings> panels = DragDropManager.DDM.AllPanels;
        
        foreach (PanelSettings panel in panels)
        {
            string panelObject = DragDropManager.GetPanelObjectId(panel.Id);

            if (panelObject != "") {
                BuildManager.Towers.Add(TowerCollection.main.GetTowerByName(panelObject));
            }
        }
    }
}
