using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField] private Transform partToRotate;
    private Vector2 direction;

    private void Update()
    {
        LookAtSpaceShip();
    }

    private void LookAtSpaceShip()
    {
        direction = (Vector2)partToRotate.position - (Vector2)SpaceShipBase.Instance.gameObject.transform.position;

        partToRotate.up = direction;
    }
}
