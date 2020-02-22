using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBulletExplosion : MonoBehaviour
{
    private string turretTag = "Turret";
    private int damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(turretTag))
        {
            collision.GetComponent<TurretBase>().GetHit(damage);
            Invoke("Deactivate", 1f);
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

}
