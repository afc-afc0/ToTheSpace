using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SpaceShipBase : MonoBehaviour
{
    #region Singleton
    protected static SpaceShipBase instance;

    public static SpaceShipBase Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField]private bool _settingPosition;
    [SerializeField]protected string shipName;
    
    public ShipProperties shipProperties;
    private HealthBar spaceShipHealthBar;
    protected bool firing;
    private int shipHealth;

    private void Awake()
    {
        instance = this;
        _settingPosition = true;
        spaceShipHealthBar = GameObject.Find("SpaceShipUI").GetComponent<HealthBar>();
        LevelControl.levelEnd += LevelEnd;
    }

    protected void GetShipData()
    {
        shipProperties = new ShipProperties(DataManager.Instance.currentShipData.health, DataManager.Instance.currentShipData.damage,DataManager.Instance.currentShipData.defense, DataManager.Instance.currentShipData.fireRate);
    }

    public void SetHealth(int amount)
    {
        shipHealth = shipProperties.ChangeHealth(amount);
        spaceShipHealthBar.SetSize(shipHealth);

        if (shipHealth <= 25)
        {
            AudioManager.Instance.Play("LowHealthSound");
        }

        if (shipHealth <= 0)
        {
            LevelControl.Instance.LevelFailed();
            gameObject.SetActive(false);
            return;
        }
    }

    void LevelEnd(bool isSuccesful)
    {
        gameObject.SetActive(false);
        LevelControl.levelEnd -= LevelEnd;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Asteroid"))
        {
            SetHealth(collider.GetComponent<Asteroid>().crashDamage);
        }
    }

    public virtual void PoolBullets()
    {
        Debug.Log("this virtual function have to be overridin");
    }

    public void StopForSeconds(float time)
    {
        _settingPosition = false;
        Invoke("SetPosition",time);
    }

    private void SetPosition()
    {
        _settingPosition = true;
    }

    public bool GetSettingPosition()
    {
        return _settingPosition;
    }

}



