using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(turretTag))
        {
            collision.gameObject.GetComponent<TurretBase>().GetHit(damage);
            gameObject.SetActive(false);
        }
    }
}
