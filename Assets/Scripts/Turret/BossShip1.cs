using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip1 : TurretBase
{
    [SerializeField] private float speed;
    [SerializeField]private Transform[] wayPoints;
    private Vector2 moveDirection;
    private Transform target;
    

    void Start()
    {
        startHealth = health;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("WayPoint");
        wayPoints = new Transform[objects.Length];

        for (int i = 0; i < objects.Length;i++)
        {
            wayPoints[i] = objects[i].GetComponent<Transform>();
        }

        GetWaypoint();//initialize target
        ChangeDirection();
    }

    void Update()
    {
        Move();
    }

    void ChangeDirection()
    {
        moveDirection = -(transform.position - target.transform.position);
    }

    void Move()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        if(Vector2.Distance(target.transform.position,transform.position) < 0.3f)
        {
            GetWaypoint();
            ChangeDirection();
        }
    }

    void  GetWaypoint()
    {
        target = wayPoints[Mathf.FloorToInt(Random.Range(0, wayPoints.Length - (float)1.01))];
    }

   
}
