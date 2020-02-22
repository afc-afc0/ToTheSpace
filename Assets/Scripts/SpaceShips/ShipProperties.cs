using UnityEngine;

public class ShipProperties 
{
    private int health;
    public int damage;
    public float fireRate;
    public int defense;

    public ShipProperties(int _health, int _damage, int _defense, float _fireRate)
    {
        health = _health;
        damage = _damage;
        fireRate = _fireRate;
        defense = _defense;
    }

    public int ChangeHealth(int value)
    {
        health -= value;
        return health;
    }

}
