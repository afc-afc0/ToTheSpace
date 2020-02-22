using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShip : SpaceShipBase
{
    public bool Firing;
    public bool inGame; 

    void Start()
    {
        Firing = true;
        GetShipData();
        PoolBullets();
    }

    public override void PoolBullets()
    {
        ObjectPooler.Instance.AddPoolObject(Resources.Load("Bullet") as GameObject, 7, true);
    }
}
