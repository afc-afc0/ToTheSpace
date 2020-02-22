using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : TurretBulletBase
{  
    void Update()
    {
        MoveBullet();
    }

    private void Start()
    {
        AudioManager.Instance.Play("BulletSound");
    }

}
