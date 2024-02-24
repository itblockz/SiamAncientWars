using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("References")]
    [SerializeField] private Transform startPoint;
    public Transform StartPoint { get => startPoint; }
    [SerializeField] private Transform[] path;
    public Transform[] Path { get => path; }
    [SerializeField] private GameOverScreen gameOverScreen;

    [Header("Attributes")]
    [SerializeField] private int currency = 100;
    public int Currency { get => currency; }

    [SerializeField] private int hitPoints = 10;
    
    private void Awake() {
        main = this;
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

        if (hitPoints <= 0) {
            GameOver();
            gameObject.SetActive(false);
        }
    }

    public void GameOver() {
        int currentWave = GetComponent<EnemySpawner>().CurrentWave;
        gameOverScreen.Setup(currentWave - 1);
    }
}
