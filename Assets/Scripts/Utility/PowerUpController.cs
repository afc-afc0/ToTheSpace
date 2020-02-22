using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    #region SINGLETON
    private static PowerUpController instance;

    public static PowerUpController Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    public delegate void ChangeFireRate(float time);
    public static event ChangeFireRate changeFireRate;
    
    public delegate void ChangeDamage(float time);
    public static event ChangeDamage changeDamage;

    public delegate void ShipShieldActivate(float time);
    public static event ShipShieldActivate shipShieldActivate;

    [SerializeField] private float startTime;
    [SerializeField] private float endTime;

    public GameObject[] positions;

    [Header("POWER UP PREFABS")]
    [SerializeField] private GameObject healthPowerUp;
    [SerializeField] private GameObject damagePowerUp;
    [SerializeField] private GameObject fireRatePowerUp;
    [SerializeField] private GameObject shieldPowUp;
    [SerializeField] private int powerUpCount = 4;


    private bool isSpawned;  

    private void Awake()
    {
        instance = this;
        positions = GameObject.FindGameObjectsWithTag("PowerUpPosition");
        SpawnPowerUpRandomTime();
    }

   
    private void SpawnPowerUpRandomTime()
    {
        Invoke("SpawnPowerUp",UnityEngine.Random.Range(startTime,endTime));
    }

    public void OnPickUp()
    {
        isSpawned = false;
        SpawnPowerUpRandomTime();
    }

    private void SpawnPowerUp()
    {
        int powUpNum = (int)UnityEngine.Random.Range(0f, powerUpCount);
        
        if (powUpNum == 0)
        {
            healthPowerUp.transform.position = GetTransform().position;
            healthPowerUp.SetActive(true);
        }
        else if(powUpNum == 1)
        {
            damagePowerUp.transform.position = GetTransform().position;
            damagePowerUp.SetActive(true);
        }
        else if(powUpNum == 2)
        {
            fireRatePowerUp.transform.position = GetTransform().position;
            fireRatePowerUp.SetActive(true);
        }
        else if(powUpNum == 3)
        {
            shieldPowUp.transform.position = GetTransform().position;
            shieldPowUp.SetActive(true);
        }
        else
        {
            Debug.Log("the isnt pow up with that num : " + powUpNum);
            return;
        }

        isSpawned = true;
    }

    public void FireRatePowerUp(float timer)
    {
        changeFireRate(timer);
        OnPickUp();
    }

    public void DamagePowerUp(float timer)
    {
        changeDamage(timer);
        OnPickUp();
    }

    public void HealthPowerUp(int health)
    {
        SpaceShipBase.Instance.SetHealth(-health);
        OnPickUp();
    }

    public void ShieldPowerUp(float timer)
    {
        shipShieldActivate(timer);
        OnPickUp();
    }

    private Transform GetTransform()
    {
        return positions[(int)UnityEngine.Random.Range(0f,positions.Length)].transform;
    }

}
