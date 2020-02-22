using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO implement MonoBehaviour and the add script to ship 
public class ShipPowerUp : MonoBehaviour
{
    public int startHealth;
    public ShipProperties shipProperties;
    Collider shipCollider;
    [SerializeField] private float increaseFireRateTimer;
    [SerializeField] private float increaseDamageTimer;
    [SerializeField] private float increaseShieldTimer;

    private void Awake()
    {
        shipCollider = GetComponent<Collider>();
        increaseDamageTimer = 3f;
        increaseFireRateTimer = 3f;
        increaseShieldTimer = 2.5f;
    }

    private void Start()
    {
        //startHealth from player instance
    }

    public void OnShieldPowerUp()
    {
        StartCoroutine(FullShield());
    }

    IEnumerator FullShield()
    {
        shipCollider.enabled = false;
        //shieldAnim.SetActive(true);
        yield return new WaitForSeconds(increaseShieldTimer);
        //shieldAnim.SetActive(false);
        shipCollider.enabled = true;
    }

    public void OnFireRatePowerUp()
    {
        StartCoroutine(IncreaseFireRate());
    }

    IEnumerator IncreaseFireRate()
    {
        shipProperties.fireRate /= 2;
        yield return new WaitForSeconds(increaseFireRateTimer);
        shipProperties.fireRate *= 2;
    }

    public void OnDamagePowerUp()
    {
        StartCoroutine(IncreaseDamage());
    }

    IEnumerator IncreaseDamage()
    {
        shipProperties.damage *= 2;
        yield return new WaitForSeconds(increaseDamageTimer);
        shipProperties.damage /= 2;
    }
}
