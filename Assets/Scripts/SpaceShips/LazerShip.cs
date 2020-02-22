using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShip : SpaceShipBase
{
    private void Start()
    {
        shipName = "LaserShip";
        firing = true;
        GetShipData();
        PoolBullets();
    }

    public override void PoolBullets()
    {
        ObjectPooler.Instance.AddPoolObject(Resources.Load("LaserBullet") as GameObject,6,true);
    }


}
