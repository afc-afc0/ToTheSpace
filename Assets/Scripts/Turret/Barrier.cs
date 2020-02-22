using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]private int health;

    [Header("BOUNTY")]
    [SerializeField]private int diamondBounty;
    [SerializeField] private int goldBounty;

    private string bulletTag = "Bullet";

    public void GetHit(int damage)
    {
        health -= damage;
        if (health <= 0 && gameObject.activeInHierarchy != false)
        {
            gameObject.SetActive(false);
            OnTowerDisable();
        }
    }

    void OnTowerDisable()
    {
        DataManager.Instance.ChangePlayerData(diamondBounty,goldBounty);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            GetHit(collision.gameObject.GetComponent<BulletBase>().GetDamage());
        }
    }

}
