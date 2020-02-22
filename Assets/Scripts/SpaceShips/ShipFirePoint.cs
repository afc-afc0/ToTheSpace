using System.Collections;
using UnityEngine;

public class ShipFirePoint : MonoBehaviour
{
    private string bulletTag;
    [SerializeField]private float fireRate;
    [SerializeField]private bool firing;
    void Awake()
    {
        firing = true;
        bulletTag = "Bullet";
    }

    private void Start()
    {
        fireRate =  SpaceShipBase.Instance.shipProperties.fireRate;
        StartCoroutine(SpawnBulletFirePoint());
        PowerUpController.changeFireRate += FireRatePowerUp;
    }

    IEnumerator SpawnBulletFirePoint()
    {
        yield return new WaitForSeconds(0.25f);
        while (firing == true)
        {
            GameObject bullet = ObjectPooler.Instance.GetPoolObject(bulletTag);

            if (bullet == null)
                Debug.Log("bullet is null");

            bullet.gameObject.transform.position = gameObject.transform.position;
            bullet.gameObject.SetActive(true);
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void FireRatePowerUp(float timer)
    {
        StartCoroutine(PowerUpTimer(timer));
    }

    private IEnumerator PowerUpTimer(float time)
    {
        fireRate /= 2;
        yield return new WaitForSeconds(time);
        fireRate *= 2;
    }

    private void OnDestroy()
    {
        PowerUpController.changeFireRate -= FireRatePowerUp;
    }
}
