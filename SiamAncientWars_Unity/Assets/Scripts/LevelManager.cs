using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("References")]
    public Transform startPoint;
    public Transform[] path;
    [SerializeField] private GameEndScreen gameOverScreen;
    [SerializeField] private GameEndScreen gameWinScreen;
    [SerializeField] private HealthBar healthBar;

    [Header("Attributes")]
    public int currency = 100;
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private int wave = 10;

    private bool gameEnd = false;
    
    private void Awake() {
        main = this;
    }

    private void Start() {
        healthBar.SetMaxHealth(hitPoints);
    }

    private void Update() {
        int currentWave = GetComponent<EnemySpawner>().CurrentWave;
        if (!gameEnd && currentWave - 1 == wave) {
            gameEnd = true;
            GameWin();
        }
    }

    public void IncreaseCurrency(int amount) {
        currency += amount;
    }

    public bool SpendCurrency(int amount) {
        if (amount <= currency) {
            // BUY ITEM
            currency -= amount;
            return true;
        } else {
            Debug.Log("You do not have enough to purchase this item");
            return false;
        }
    }

    public void TakeDamage(int dmg) {
        hitPoints -= dmg;
        healthBar.SetHealth(hitPoints);

        if (hitPoints <= 0) {
            gameEnd = true;
            GameOver();
        }
    }

    public void GameOver() {
        int currentWave = GetComponent<EnemySpawner>().CurrentWave;
        gameOverScreen.Setup(currentWave - 1);
        gameObject.SetActive(false);
    }

    public void GameWin() {
        int cleared = GetComponent<EnemySpawner>().CurrentWave - 1;
        gameWinScreen.Setup(cleared);
        Player.main.MapCleared = cleared;
        gameObject.SetActive(false);
    }
}
