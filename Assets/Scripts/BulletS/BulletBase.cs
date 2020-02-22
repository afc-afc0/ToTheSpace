using UnityEngine;
using System.Collections;
public class BulletBase : MonoBehaviour 
{

    [SerializeField]protected float speed = 30f;
    protected int damage;
    protected string turretTag = "Turret";

    private void Start()
    {
        damage = SpaceShipBase.Instance.shipProperties.damage;
        PowerUpController.changeDamage += OnDamagePowerUp;
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnDamagePowerUp(float timer)
    {
        if(gameObject.activeInHierarchy)
            StartCoroutine(DamagePowerUp(timer));
    }

    public IEnumerator DamagePowerUp(float timer)
    {
        damage *= 2;
        yield return new WaitForSeconds(timer);
        damage /= 2;
    }

    private void OnDestroy()
    {
        PowerUpController.changeDamage -= OnDamagePowerUp;
    }

}
