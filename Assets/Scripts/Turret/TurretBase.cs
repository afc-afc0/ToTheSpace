using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretBase : MonoBehaviour
{
    #region TOWER ATTIRIBUTES
    [Header("TOWER ATTIRIBUTES")]
    [SerializeField] protected int health;
    protected int startHealth;
    #endregion

    [Header("UI")]
    [SerializeField] private Transform healthBar;
    private float startScale;



    [Header("BOUNTY")]
    public int diamondBounty;
    public int goldBounty;

    protected string bulletTag = "Bullet";

    private void Awake()
    {
        startHealth = health;
        startScale = healthBar.localScale.x;
    }

    public void GetHit(int damage)
    {
        health -= damage;
        SetSize(startHealth);
        if (health <= 0 && gameObject.activeInHierarchy != false)
        {
            gameObject.SetActive(false);
            OnTowerDisable();
        }
    }

    public void SetSize(int startHealth)
    {
        float size = (float)health / (float)startHealth;
        healthBar.localScale = new Vector2(size * startScale, healthBar.localScale.y);
    }

    void OnTowerDisable()
    {
        TowerControl.Instance.OnTowerDestroy(goldBounty,diamondBounty);
    }

    public void SetHealth(int _health)
    {
        health = _health;
    }

}
