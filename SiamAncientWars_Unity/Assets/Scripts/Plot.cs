using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject towerObj;
    public Turret turret;
    private Color startColor;

    private PlayerInput playerInput;
    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("TouchPress");
        touchPositionAction = playerInput.actions.FindAction("TouchPosition");
    }

    private void OnEnable() {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable() {
        touchPressAction.performed -= TouchPressed;
    }

    private void Start() {
        startColor = sr.color;
    }

    // private void OnMouseEnter() {
    //     sr.color = hoverColor;
    // }

    // private void OnMouseExit() {
    //     sr.color = startColor;
    // }

    // private void OnMouseDown() {
    //     if (tower != null) return;

    //     GameObject towerToBuild = BuildManager.main.GetSelectedTower();
    //     tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    // }

    private void TouchPressed(InputAction.CallbackContext context) {
        if (!IsTouchingObject()) return;

        if (UIManager.main.IsHoveringUI()) return;
        
        if (towerObj != null) {
            turret.OpenUpgradeUI();
            return;
        }

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.currency) {
            Debug.Log("You can't afford this tower");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        towerObj = Instantiate(towerToBuild.model, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();
    }

    private bool IsTouchingObject()
    {
        // Convert touch position to world position
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touchPositionAction.
            ReadValue<Vector2>());

        // Raycast to check if the touch hits this object
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

        // Check if the raycast hit this object
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        return false;
    }
}
