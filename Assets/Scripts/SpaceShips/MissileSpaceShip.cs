using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpaceShip : SpaceShipBase
{
    void Start()
    {
        firing = true;
        GetShipData();
        PoolBullets();
    }

    public override void PoolBullets()
    {
        ObjectPooler.Instance.AddPoolObject(Resources.Load("MissileBullet") as GameObject, 6, true);
        ObjectPooler.Instance.AddPoolObject(Resources.Load("Explode") as GameObject, 6, true);
    }


}
