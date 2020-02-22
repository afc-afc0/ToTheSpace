using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltTurret : TurretBase
{
    [SerializeField] private bool isFollowing;
    [SerializeField] private float speed;

    [SerializeField] private GameObject lazer;
    [SerializeField] private GameObject beforeLazer;

    [SerializeField] private float fireRate;


    private void Start()
    {
        StartCoroutine(Fire());
    }

    void Update()
    {
        if(isFollowing)
            Follow();
    }
    
    void Follow()
    {
        if (SpaceShip.Instance.transform.position.x - transform.position.x > 0.2f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(SpaceShip.Instance.transform.position.x - transform.position.x < -0.2f)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    IEnumerator Fire()
    {
        while(true)
        {
            beforeLazer.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            beforeLazer.SetActive(false);
            lazer.SetActive(true);
            AudioManager.Instance.Play("BoltSound");
            yield return new WaitForSeconds(1f);
            lazer.SetActive(false);
            yield return new WaitForSeconds(fireRate);
        }
    }

    

}
