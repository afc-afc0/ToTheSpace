using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private int damage;

    private string spaceShipTag = "SpaceShip";

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(spaceShipTag))
        {
            SpaceShipBase.Instance.SetHealth(damage);
        }
    }
}
