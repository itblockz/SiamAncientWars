using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bps = 1f; // Bullets Per Second
    
    private int cost;
    [HideInInspector] public Tower tower;

    
    private float bpsBase;
    private float targetingRangeBase;

    private Transform target;
    private float timeUntilFire;

    private int level = 1;

    private void Start()
    {
        cost = tower.cost;
        bpsBase = bps;
        targetingRangeBase = targetingRange;
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
        transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x -
        transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation,
        targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void Upgrade()
    {
        cost = CalculateCost();
        if (cost > LevelManager.main.currency) return;

        LevelManager.main.SpendCurrency(cost);

        level++;
        
        bps = CalculateBPS();
        targetingRange = CalculateRange();
        Debug.Log("New Level: " + level);
        Debug.Log("New BPS: " + bps);
        Debug.Log("New Range: " + targetingRange);
        Debug.Log("New Cost: " + cost);
    }

    public void Sell()
    { 
        Debug.Log("Currency: " + LevelManager.main.currency);
        LevelManager.main.currency += Mathf.RoundToInt(cost * 0.75f);
        Debug.Log("Mathf: " + Mathf.RoundToInt(cost * 0.75f));
        Debug.Log("Currency after cal: " + LevelManager.main.currency);
        Destroy(gameObject);
    }

    private int CalculateCost()
    {
        return Mathf.RoundToInt(tower.cost * Mathf.Pow(level, 0.8f));
    }

    private float CalculateBPS()
    {
        return bpsBase * Mathf.Pow(level, 0.6f);
    }

    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(level, 0.4f);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
#endif

}
