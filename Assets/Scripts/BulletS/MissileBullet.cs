using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : BulletBase
{
    private string explosionTag;
  
    private void Start()
    {
        explosionTag = "Explode";        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(turretTag))
        {
            Explode(collision.transform);
        }
    }

    private void Explode(Transform position)
    {
        GameObject obj = ObjectPooler.Instance.GetPoolObject(explosionTag);
        obj.transform.position = position.position;
        obj.GetComponent<MissileBulletExplosion>().SetDamage(damage);
        obj.SetActive(true);
    }

}
