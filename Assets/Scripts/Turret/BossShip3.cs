using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip3 : TurretBase
{
    [Header("Seeking Values")]
    public float speed = 2f;
    public float rotateSpeed = 50f;
    private string shipTag = "SpaceShip";
    public GameObject target;

    private Rigidbody2D rb;

    private void Start()
    {
        startHealth = health;

        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag(shipTag);
    }

    private void FixedUpdate()
    {
        SeekTarget();
    }

    void SeekTarget()
    {
        if (Vector2.Distance(rb.position, target.transform.position) >= 1.5f)
        {
            Vector2 direction =  (Vector2)target.transform.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = rotateAmount * rotateSpeed;

            rb.velocity = -transform.up * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

}
