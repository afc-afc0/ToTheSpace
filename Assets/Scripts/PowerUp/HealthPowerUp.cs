using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField] private int healthAmount;

    protected override void OnPickup()
    {
        PowerUpController.Instance.HealthPowerUp(healthAmount);
    }
}
