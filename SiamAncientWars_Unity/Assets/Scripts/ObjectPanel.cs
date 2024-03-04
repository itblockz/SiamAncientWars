using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectPanel : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private GameObject prefab;

    public void Start() {
        Tower[] towers = TowerCollection.main.towers;

        for (int i = 0; i < towers.Length; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            ObjectSettings objectSettings = obj.GetComponent<ObjectSettings>();
            string id = towers[i].name;
            objectSettings.Id = id;
            obj.GetComponent<Image>().sprite = towers[i].sprite;

            UnityEvent unityEvent = new UnityEvent();
            unityEvent.AddListener(delegate {
                if (DragDropManager.GetObjectById(id) == null) {
                    DragDropManager.AddObject(objectSettings);
                }
                GetComponent<GridLayoutGroup>().enabled = false;
            });
            objectSettings.OnBeginDragging = unityEvent;
        }
    }
}
