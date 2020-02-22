using UnityEngine;

public class SpikeTower : MonoBehaviour
{
    public int damage;

    private string spaceShipTag = "SpaceShip";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(spaceShipTag))
        {
            collision.GetComponent<SpaceShipBase>().SetHealth(damage);
        }
    }

}
