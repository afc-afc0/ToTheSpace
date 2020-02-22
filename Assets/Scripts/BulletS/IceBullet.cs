using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : TurretBulletBase
{
    [SerializeField] private float stopTime = 0.1f;

    void Update()
    {
        MoveBullet();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(shipTag))
        {
            collider.GetComponent<SpaceShipBase>().StopForSeconds(stopTime);
            gameObject.SetActive(false);
        }
    }
}
