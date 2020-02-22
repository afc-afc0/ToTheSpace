using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private string spaceShipTag = "SpaceShip";

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(spaceShipTag))
        {
            OnPickup();
            gameObject.SetActive(false);
        }
    }

    protected virtual void OnPickup()
    { 
        Debug.Log("This Function have to be overridin");
    }
}
