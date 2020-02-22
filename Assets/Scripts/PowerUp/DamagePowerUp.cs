using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUp
{
    [SerializeField]private float timer;
    protected override void OnPickup()
    {
        PowerUpController.Instance.DamagePowerUp(timer);
    }
}
