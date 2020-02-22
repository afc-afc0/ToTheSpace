using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]private GameObject poolObject;
    [SerializeField]private int bulletCount;
    [SerializeField]private GameObject[] bullets;
    [SerializeField]private List<GameObject> extraBulletList;

    private void Awake()
    {
        PoolBullets();
    }

    private void PoolBullets()
    {
        bullets = new GameObject[bulletCount];

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(poolObject);
            bullet.SetActive(false);
            bullets[i] = bullet;
        }
    }

    public GameObject GetBullet()//we first use simple array because of performance for excess ones we use List 
    {
        for(int i = 0; i < bulletCount;i++)
        {
            if(bullets[i].activeInHierarchy == false)
            {
                return bullets[i];
            }
        }

        for(int i = 0;i < extraBulletList.Count;i++)
        {
            if(extraBulletList[i].activeInHierarchy == false)
            {
                return extraBulletList[i];
            }
        }

        GameObject newBullet = Instantiate(poolObject);
        newBullet.SetActive(false);
        Debug.Log("adding Bullet To List");
        extraBulletList.Add(newBullet);

        return newBullet;
    }

}
