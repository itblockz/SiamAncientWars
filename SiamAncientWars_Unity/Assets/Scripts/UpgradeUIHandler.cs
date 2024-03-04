using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI nameTurret;
    [SerializeField] private GameObject imageTurret;
    public bool mouse_over = false;

    public void OnPointerEnter(PointerEventData eventData) {
        mouse_over = true;
        UIManager.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        mouse_over = false;
        UIManager.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }
    private void OnGUI(){
        Sprite image_sprite = Shop.tmp_img;
        GameObject imageObj = Instantiate(imageTurret, transform);
        Image img = imageObj.GetComponent<Image>();
        img.sprite = image_sprite;
        nameTurret.text = Turret.nameTurret.ToString();
    }
}
