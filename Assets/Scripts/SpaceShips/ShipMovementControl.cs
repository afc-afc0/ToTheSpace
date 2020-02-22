using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementControl : MonoBehaviour
{
    Collider shipCollider;
    Vector3 pos;
    private Camera mainCamera;
    private float cameraOffSet;
    [SerializeField]private Transform limitPosition;

    void Awake()
    {
        shipCollider = GetComponent<Collider>();
        cameraOffSet = 10f;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        SetPosition();
    }

    private void OnMouseDrag()
    {
        SetPosition();
    }


    private void OnMouseUp()
    {
        SetPosition();
    }

    void SetPosition()
    {
        if (SpaceShipBase.Instance.GetSettingPosition())
        {
            pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = pos.z + cameraOffSet;

            if (pos.y > limitPosition.position.y)
            {
                pos.y = limitPosition.position.y;
            }

            SpaceShipBase.Instance.transform.position = pos;
        }
    }
}
