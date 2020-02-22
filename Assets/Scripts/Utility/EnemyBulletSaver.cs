using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSaver : MonoBehaviour
{

    private string enemyBulletTag = "EnemyBullet";

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(enemyBulletTag))
        {
            collider.gameObject.SetActive(false);
        }
    }

   
}
