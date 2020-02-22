using UnityEngine;

public class Space : MonoBehaviour
{
    private GameObject spaceShip;

    private Vector3 pos;
    private float cameraOffSet = +10f;
    private string spaceShipTag = "SpaceShip" ;

    void Start()
    {
        spaceShip = GameObject.FindGameObjectWithTag(spaceShipTag);
    }

    void OnMouseDown()
    {
        SetPosition();
    }

    void OnMouseDrag()
    {
        SetPosition();
    }

    void OnMouseUp()
    {
        SetPosition();
    }

    void SetPosition()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = pos.z + cameraOffSet;
    }



}
