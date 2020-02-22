using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int damage;
    public void OnEnable()
    {
        Invoke("Deactivate",1f);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpaceShip"))
        {
            collision.gameObject.GetComponent<SpaceShipBase>().SetHealth(damage);
        }
    }

}
