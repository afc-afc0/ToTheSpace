using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [SerializeField] private float timer;
    protected override void OnPickup()
    {
        PowerUpController.Instance.ShieldPowerUp(timer);
    }
}
