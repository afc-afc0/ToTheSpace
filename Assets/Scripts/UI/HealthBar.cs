using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Transform pivot;

    private int startHealth;
    private float size;

    private void Start()
    {
        startHealth = DataManager.Instance.currentShipData.health;
    }

    public void SetSize(int currentHealth)
    {
        if (currentHealth <= 0)
            gameObject.SetActive(false);

        size = (float)currentHealth / (float)startHealth;
        pivot.localScale = new Vector2(size,1f);
    }

}
