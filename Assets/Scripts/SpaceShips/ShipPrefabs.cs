using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipPrefabs 
{
    public GameObject normalShipPrefab;
    public GameObject doubleFirePrefab;
    public GameObject tripleFirePrefab;
    public GameObject missileShipPrefab;

    public GameObject currentShip;

    [Header("ShipBulletPrefabs")]
    public GameObject normalBullet;
    public GameObject missileBullet;

    public ShipPrefabs(string shipName)
    {
        
            
    }
}
