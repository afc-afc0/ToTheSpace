using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : PowerUp
{
    [SerializeField] private float timer;
    protected override void OnPickup()
    {
        PowerUpController.Instance.FireRatePowerUp(timer);
    }
}
