using System.Collections;
using UnityEngine;

public class ShipShield : MonoBehaviour
{
    Collider2D shipCollider;
    private void Start()
    {
        shipCollider = gameObject.GetComponentInParent<Collider2D>();
        StartCoroutine(ShieldPowerUp(1.5f));
        PowerUpController.shipShieldActivate += OnPickup;
    }

    void OnPickup(float timer)
    {
        gameObject.SetActive(true);
        StartCoroutine(ShieldPowerUp(timer));
    }

    private IEnumerator ShieldPowerUp(float timer)
    {
        shipCollider.enabled = false;
        yield return new WaitForSeconds(timer);
        shipCollider.enabled = true;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PowerUpController.shipShieldActivate -= OnPickup;
    }
}
