using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletBase : MonoBehaviour
{
    [Header("BULLET PROPERTİES")]
    [SerializeField]protected int speed;
    [SerializeField]protected int damage;

    protected string shipTag = "SpaceShip";
    protected string bulletTag = "Bullet";

 
    protected virtual void MoveBullet()
    {
        gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(shipTag))
        {
            collision.gameObject.GetComponent<SpaceShipBase>().SetHealth(damage);
            gameObject.SetActive(false);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int val)
    {
        damage = val;
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }

}
