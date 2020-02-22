using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip2 : TurretBase
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed;

    [Header("For Direction")]
    private Vector2 moveDirection;
    private Transform moveTarget;

    private void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("WayPoint");
        wayPoints = new Transform[objects.Length];

        startHealth = health;

        for (int i = 0; i < objects.Length; i++)
        {
            wayPoints[i] = objects[i].GetComponent<Transform>();
        }

        GetWaypoint();
        ChangeDirection();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        if (Vector2.Distance(moveTarget.transform.position, transform.position) < 0.3f)
        {
            GetWaypoint();
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveDirection = moveTarget.transform.position - transform.position;
    }

    void GetWaypoint()
    {
        moveTarget = wayPoints[Mathf.FloorToInt(Random.Range(0, wayPoints.Length - (float)1.01))];
    }

}
