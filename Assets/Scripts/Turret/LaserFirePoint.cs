using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFirePoint : TurretFirePoint
{
    [SerializeField]private float timeBetweenBullets;
    [SerializeField] private int bulletCount;
    protected override IEnumerator Fire()
    {
        yield return new WaitForSeconds(startFireTimer);
        while(isFiring)
        {
            for(int i = 0; i < bulletCount;i++)
            { 
                bullet = bulletPool.GetBullet();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.gameObject.SetActive(true);

                PlayAudio();
                yield return new WaitForSeconds(timeBetweenBullets);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
}
