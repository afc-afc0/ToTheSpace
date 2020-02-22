using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

[System.Serializable]
public class ShipDatas
{
    public NormalShipData normalShip;
    public DoubleFireData doubleFire;
    public TripleFireData tripleFire;
    public MissileShipData missileShip;
    public LaserShipData laserShip;

    public ShipDatas()
    {
        normalShip = new NormalShipData();
        doubleFire = new DoubleFireData();
        tripleFire = new TripleFireData();
        missileShip = new MissileShipData();
        laserShip = new LaserShipData();
    }

}

[System.Serializable]
public abstract class SpaceShipData
{
    public string shipName;
    public int shipPrice;
    public int damage;
    public float fireRate;
    public int health;
    public int defense;
    public bool isBought;

    public void AddDamage(int damage)
    {
        this.damage += damage;
    }

    public void AddHealth(int health)
    {
        this.health += health;
    }

    public void AddFireRate(float fireRate)
    {
        this.fireRate -= fireRate;
    }

    public void AddDefense(int defense)
    {
        this.defense += defense;
    }

}

[System.Serializable]
public class NormalShipData : SpaceShipData
{
    public NormalShipData()
    {
        shipName = "NormalShip";
        shipPrice = 0;
        damage = 10;
        fireRate = 0.62f;
        health = 100;
        defense = 0;
        isBought = true;
    }
}

[System.Serializable]
public class DoubleFireData : SpaceShipData
{
    public DoubleFireData( )
    {
        shipName = "DoubleFire";
        shipPrice = 400;
        damage = 10;
        fireRate = 0.62f;
        health = 120;
        defense = 1;
        isBought = false;
     }
}

[System.Serializable]
public class TripleFireData : SpaceShipData
{
    public TripleFireData( )
    {
        shipName = "TripleFire";
        shipPrice = 800;
        damage = 12;
        fireRate = 0.52f;
        health = 150;
        defense = 2;
        isBought = false;
    }
}

[System.Serializable]
public class MissileShipData : SpaceShipData
{
    public MissileShipData( )
    {
        shipName = "MissileShip";
        shipPrice = 600;
        damage = 10;
        health = 200;
        fireRate = 0.82f;
        defense = 4;
        isBought = false;
    }
}

[System.Serializable]
public class LaserShipData : SpaceShipData
{
    public LaserShipData()
    {
        shipName = "LaserShip";
        shipPrice = 800;
        damage = 10;
        health = 150;
        fireRate = 0.70f;
        defense = 2;
        isBought = false;
    }
}

