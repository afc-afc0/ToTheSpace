using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSpaceShip : MonoBehaviour
{
    public float speed = 2f;
    public float rotateSpeed = 170f;

    private string shipTag = "SpaceShip";

    [Range(1.5f, 7f)]
    [SerializeField] private float stopDistance = 1.5f; 

    private Rigidbody2D rb;

    public GameObject target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag(shipTag);
    }

    void FixedUpdate()
    {
        SeekTarget();
    }

    void SeekTarget()
    {
        if (Vector2.Distance(rb.position,target.transform.position) >= stopDistance)
        {
            Vector2 direction =  (Vector2)target.transform.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
